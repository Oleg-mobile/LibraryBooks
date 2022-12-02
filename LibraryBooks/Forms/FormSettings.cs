using FluentValidation;
using LibraryBooks.Core.Models;
using LibraryBooks.Core.Repositories;
using LibraryBooks.Dto;
using LibraryBooks.Utils;
using LibraryBooks.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace LibraryBooks.Forms
{
    public partial class FormSettings : FormLibrarryBooks
    {
        private readonly IRepository<User, int> _userRepository;
        private readonly IRepository<Reader, int> _readerRepository;
        private readonly IValidator<FormReader> _validator;
        private BindingList<ReaderDto> bindingList;

        public FormSettings()
        {
            InitializeComponent();

            _userRepository = Resolve<IRepository<User, int>>();
            _readerRepository = Resolve<IRepository<Reader, int>>();
            _validator = Resolve<IValidator<FormReader>>();

            // INFO: заполнение dataGridView при открытии формы
            RefrashTable();
            InitDataGridViewColumns<ReaderDto>(dataGridViewReaders);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var readerForm = new FormReader();
            DialogResult result = readerForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                _validator.ValidateAndThrow(readerForm);

                Reader reader = new Reader
                {
                    UserId = _userRepository.GetAll().First(u => u.Login == Session.CurrentUser.Login).Id,
                    Name = readerForm.textBoxName.Text,
                    PathToReader = readerForm.textBoxPathToReader.Text,
                    OpeningFormat = readerForm.textBoxOpeningFormat.Text
                };

                _readerRepository.Insert(reader);

                RefrashTable();
            }
            catch (ValidationException ex)
            {
                var message = ex.Errors?.First().ErrorMessage ?? ex.Message;
                Notification.ShowWarning(message);
            }
        }

        private void buttonDell_Click(object sender, EventArgs e)
        {
            var readers = SelectedRowsMapToReaders();

            foreach (var reader in readers)
            {
                _readerRepository.Delete(reader);
            }

            RefrashTable();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewReaders.SelectedRows.Count > 0)
            {
                var readerDto = (ReaderDto)dataGridViewReaders.SelectedRows[0].DataBoundItem;
                var readerForm = new FormReader(readerDto);
            // TODO метка
            LabelShow1:
                DialogResult dialogResult = readerForm.ShowDialog();

                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                try
                {
                    var validator = new FormReaderValidator();
                    validator.ValidateAndThrow(readerForm);

                    var reader = Mapper.Map<Reader>(readerDto);
                    reader.Name = readerForm.textBoxName.Text;
                    reader.PathToReader = readerForm.textBoxPathToReader.Text;
                    reader.OpeningFormat = readerForm.textBoxOpeningFormat.Text;
                    reader.UserId = _userRepository.GetAll().First(u => u.Login == Session.CurrentUser.Login).Id;

                    _readerRepository.Update(reader);

                    RefrashTable();
                }
                catch (ValidationException ex)
                {
                    var message = ex.Errors.First().ErrorMessage ?? ex.Message;
                    Notification.ShowWarning(message);

                    goto LabelShow1;
                }
            }
        }

        private IEnumerable<Reader> SelectedRowsMapToReaders()
        {
            var readers = new List<ReaderDto>();

            for (int i = 0; i < dataGridViewReaders.SelectedRows.Count; i++)
            {
                var reader = (ReaderDto)dataGridViewReaders.SelectedRows[i].DataBoundItem;
                readers.Add(reader);
            }

            return Mapper.Map<IEnumerable<Reader>>(readers);
        }

        private void RefrashTable()
        {
            var readers = _readerRepository
                .GetAll()
                .Include(r => r.User)
                .AsNoTracking()
                .ToList();

            bindingList = new BindingList<ReaderDto>(Mapper.Map<IList<ReaderDto>>(readers));
            dataGridViewReaders.DataSource = bindingList;
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            new FormPasswordChange().ShowDialog();
        }
    }
}
