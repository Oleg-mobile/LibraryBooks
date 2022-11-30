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
        private OpenFileDialog ofd = new OpenFileDialog();

        private readonly IRepository<User, int> _userRepository;
        private readonly IRepository<Reader, int> _readerRepository;
        private BindingList<ReaderDto> bindingList;

        public FormSettings()
        {
            InitializeComponent();

            ofd.Title = "Выберите программу";
            ofd.Filter = "Программы|*.exe";
            textBoxFilePath.Text = "C:\\Program Files\\Adobe\\Acrobat DC\\Acrobat\\Acrobat.exe";

            _userRepository = Resolve<IRepository<User, int>>();
            _readerRepository = Resolve<IRepository<Reader, int>>();
        }

        private void buttonGetPath_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() != DialogResult.OK) return;
            textBoxFilePath.Text = ofd.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FormPasswordChange().Show();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var readerForm = new FormReader();
            DialogResult result= readerForm.ShowDialog();

            if (result == DialogResult.Cancel) 
            {
                return;
            }

            try
            {
                var validator = new FormReaderValidator();
                validator.ValidateAndThrow(readerForm);

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
    }
}
