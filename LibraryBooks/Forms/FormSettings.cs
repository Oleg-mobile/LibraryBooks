using LibraryBooks.Core.Models;
using LibraryBooks.Core.Repositories;
using LibraryBooks.Dto;
using LibraryBooks.Utils;
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
        private readonly IRepository<Book, int> _bookRepository;
        private BindingList<ReaderDto> bindingList;

        public FormSettings()
        {
            InitializeComponent();

            _userRepository = Resolve<IRepository<User, int>>();
            _readerRepository = Resolve<IRepository<Reader, int>>();
            _bookRepository= Resolve<IRepository<Book, int>>();

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

        private void buttonDell_Click(object sender, EventArgs e)
        {
            var readers = SelectedRowsMapToReaders();

            foreach (var reader in readers)
            {
                var books = _bookRepository.GetAll().AsNoTracking().Where(b => b.Reader.Id ==  reader.Id).ToList();
                foreach (var book in books)
                {
                    book.ReaderId = null;
                    _bookRepository.Update(book);
                }

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

                var reader = Mapper.Map<Reader>(readerDto);
                reader.Name = readerForm.textBoxName.Text;
                reader.PathToReader = readerForm.textBoxPathToReader.Text;
                reader.OpeningFormat = readerForm.textBoxOpeningFormat.Text;
                reader.UserId = _userRepository.GetAll().First(u => u.Login == Session.CurrentUser.Login).Id;

                _readerRepository.Update(reader);

                RefrashTable();
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
