using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tyuiu.KislayaVA.Sprint7.Project.V4
{
    public partial class FormMain : Form
    {
        
        // Ссылаемся на файлы для открытия их по умолчанию, создаем переменные для хранения и для фильтрации
        
        private string booksFilePath = "books.csv";
        private string readersFilePath = "readers.csv";

        private DataTable booksDataTable;
        private DataTable readersDataTable;

        private DataTable booksDataTableFull;
        private DataTable readersDataTableFull;

        public FormMain()
        {
            InitializeComponent();
        }

        // Получение данных о книгах
        
        public DataTable GetBooksData()
        {
            return booksDataTableFull;
        }

        // Инициализация фильтров
        
        private void InitializeFilterComboBox()
        {
            comboBoxFiltr_KVA.Items.Clear();
            comboBoxFiltr_KVA.Items.Add("Все");
            comboBoxFiltr_KVA.Items.Add("Новые издания");
            comboBoxFiltr_KVA.Items.Add("Старые издания");
            comboBoxFiltr_KVA.Items.Add("Дорогие книги (от 700)");
            comboBoxFiltr_KVA.Items.Add("Дешевые книги (до 500)");
            comboBoxFiltr_KVA.Items.Add("Классика (до 1900 года)");
            comboBoxFiltr_KVA.SelectedIndex = 0;

            comboBox2.Items.Clear();
            comboBox2.Items.Add("Все");
            comboBox2.Items.Add("Просроченные возвраты");
            comboBox2.Items.Add("Активные займы");
            comboBox2.SelectedIndex = 0;
        }
        private void FilterReadersData()
        {
            if (comboBox2.SelectedItem == null || comboBox2.SelectedItem.ToString() == "Все")
            {
                dataGridView2.DataSource = readersDataTableFull;
                return;
            }

            string filterValue = comboBox2.SelectedItem.ToString();
            DataTable filteredTable = readersDataTableFull.Clone();

            foreach (DataRow row in readersDataTableFull.Rows)
            {
                bool includeRow = false;

                switch (filterValue)
                {
                    case "Просроченные возвраты":
                        if (row["Дата возврата"] is DateTime returnDate && returnDate < DateTime.Now)
                            includeRow = true;
                        break;

                    case "Активные займы":
                        if (row["Дата выдачи"] is DateTime issueDate &&
                            row["Дата возврата"] is DateTime returnDateActive &&
                            returnDateActive >= DateTime.Now)
                            includeRow = true;
                        break;
                }

                if (includeRow)
                {
                    filteredTable.ImportRow(row);
                }
            }

            dataGridView2.DataSource = filteredTable;
        }

        // ПОиск

        private void SearchReadersData()
        {
            string searchText = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                dataGridView2.DataSource = readersDataTableFull;
                return;
            }

            DataTable searchTable = readersDataTableFull.Clone();

            foreach (DataRow row in readersDataTableFull.Rows)
            {
                bool found = row["ФИО"].ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            row["Номер билета"].ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            row["Адрес"].ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            row["Телефон"].ToString().Contains(searchText);

                if (found)
                {
                    searchTable.ImportRow(row);
                }
            }

            dataGridView2.DataSource = searchTable;
        }

        // Загрзука формы
        
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeBooksTable();
            InitializeReadersTable();
            toolStripSaveFile_KVA.Click += toolStripSaveFile_KVA_Click;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView2.CellValueChanged += dataGridView2_CellValueChanged;
            LoadDataFromFiles();

            InitializeFilterComboBox();

            comboBoxFiltr_KVA.SelectedIndexChanged += (s, ev) => FilterDataByComboBox();
            textBoxSearch_KVA.TextChanged += (s, ev) => SearchDataByTextBox();
            comboBox2.SelectedIndexChanged += (s, ev) => FilterReadersData(); // Для читателей
            textBox2.TextChanged += (s, ev) => SearchReadersData(); // Для читателей

        }

       
        // Инициализация таблички с книгами
        private void InitializeBooksTable()
        {
            booksDataTable = new DataTable();
            booksDataTable.Columns.Add("Автор", typeof(string));
            booksDataTable.Columns.Add("Название", typeof(string));
            booksDataTable.Columns.Add("Год издания", typeof(int));
            booksDataTable.Columns.Add("Цена", typeof(decimal));
            booksDataTable.Columns.Add("Новое издание", typeof(bool));
            booksDataTable.Columns.Add("Описание", typeof(string));

            dataGridView1.DataSource = booksDataTable;
        }

        // с читателями
        private void InitializeReadersTable()
        {
            readersDataTable = new DataTable();
            readersDataTable.Columns.Add("Номер билета", typeof(string));
            readersDataTable.Columns.Add("ФИО", typeof(string));
            readersDataTable.Columns.Add("Адрес", typeof(string));
            readersDataTable.Columns.Add("Телефон", typeof(string));
            readersDataTable.Columns.Add("Дата выдачи", typeof(DateTime));
            readersDataTable.Columns.Add("Дата возврата", typeof(DateTime));

            dataGridView2.DataSource = readersDataTable;
        }

        // загрузка из файлов
        private void LoadDataFromFiles()
        {
            try
            {
                if (File.Exists(booksFilePath))
                {
                    LoadBooksFromCSV(booksFilePath);
                }
                else
                {
                    CreateSampleData();
                }

                if (File.Exists(readersFilePath))
                {
                    LoadReadersFromCSV(readersFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}\n\nБудут созданы тестовые данные.", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CreateSampleData();
            }
        }

        private void LoadBooksFromCSV(string filePath)
        {
            booksDataTable.Clear();
            var lines = File.ReadAllLines(filePath, Encoding.UTF8);

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                    continue;

                try
                {
                    var values = lines[i].Split(';');
                    if (values.Length >= 6)
                    {
                        var row = booksDataTable.NewRow();
                        row["Автор"] = values[0];
                        row["Название"] = values[1];

                        if (int.TryParse(values[2], out int year))
                            row["Год издания"] = year;
                        else
                            row["Год издания"] = DateTime.Now.Year;

                        if (decimal.TryParse(values[3], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price))
                            row["Цена"] = price;
                        else
                            row["Цена"] = 0m;

                        if (bool.TryParse(values[4], out bool isNew))
                            row["Новое издание"] = isNew;
                        else
                            row["Новое издание"] = false;

                        row["Описание"] = values[5];
                        booksDataTable.Rows.Add(row);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Ошибка обработки строки {i}: {ex.Message}");
                }
            }

            booksDataTableFull = booksDataTable.Copy();
        }

        private void LoadReadersFromCSV(string filePath)
        {
            readersDataTable.Clear();
            var lines = File.ReadAllLines(filePath, Encoding.UTF8);

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                    continue;

                try
                {
                    var values = lines[i].Split(';');
                    if (values.Length >= 6)
                    {
                        var row = readersDataTable.NewRow();
                        row["Номер билета"] = values[0];
                        row["ФИО"] = values[1];
                        row["Адрес"] = values[2];
                        row["Телефон"] = values[3];

                        if (DateTime.TryParse(values[4], out DateTime issueDate))
                            row["Дата выдачи"] = issueDate;
                        else
                            row["Дата выдачи"] = DateTime.Now;

                        if (DateTime.TryParse(values[5], out DateTime returnDate))
                            row["Дата возврата"] = returnDate;
                        else
                            row["Дата возврата"] = DateTime.Now.AddMonths(1);

                        readersDataTable.Rows.Add(row);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Ошибка обработки строки {i}: {ex.Message}");
                }
            }

            readersDataTableFull = readersDataTable.Copy();
        }

        // Образец данных (они вызываются если что то поломалось)

        private void CreateSampleData()
        {
            booksDataTable.Rows.Add("Толстой Л.Н.", "Война и мир", 1869, 450, false, "Роман-эпопея о войне 1812 года");
            booksDataTable.Rows.Add("Достоевский Ф.М.", "Преступление и наказание", 1866, 650, false, "Психологический роман о преступлении и совести");
            booksDataTable.Rows.Add("Пушкин А.С.", "Евгений Онегин", 1833, 450, false, "Роман в стихах о любви");
            booksDataTable.Rows.Add("Булгаков М.А.", "Мастер и Маргарита", 1967, 550, true, "Мистический роман о добре и зле");

            booksDataTableFull = booksDataTable.Copy();

            readersDataTable.Rows.Add("001", "Иванов Иван Иванович", "ул. Ленина, 10", "+7-900-123-4567",
                DateTime.Parse("2024-01-15"), DateTime.Parse("2024-02-15"));
            readersDataTable.Rows.Add("002", "Петрова Мария Сергеевна", "ул. Советская, 25", "+7-900-234-5678",
                DateTime.Parse("2024-02-01"), DateTime.Parse("2024-03-01"));

            readersDataTableFull = readersDataTable.Copy();
        }

        // Сохранение данных
        private void SaveDataToFiles()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
                saveFileDialog.Title = "Сохранить файл";
                saveFileDialog.DefaultExt = "csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (tabControl1.SelectedTab == tabPageBooks_KVA) // Книги
                        {
                            SaveBooksToCSV(saveFileDialog.FileName);
                        }
                        else // Читатели
                        {
                            SaveReadersToCSV(saveFileDialog.FileName);
                        }

                        MessageBox.Show("Файл успешно сохранен!", "Сохранение",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SaveBooksToCSV(string filePath)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Автор;Название;Год издания;Цена;Новое издание;Описание");

            foreach (DataRow row in booksDataTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    sb.AppendLine($"{row["Автор"]};{row["Название"]};{row["Год издания"]};{row["Цена"]};{row["Новое издание"]};{row["Описание"]}");
                }
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        private void SaveReadersToCSV(string filePath)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Номер билета;ФИО;Адрес;Телефон;Дата выдачи;Дата возврата");

            foreach (DataRow row in readersDataTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    sb.AppendLine($"{row["Номер билета"]};{row["ФИО"]};{row["Адрес"]};{row["Телефон"]};{row["Дата выдачи"]};{row["Дата возврата"]}");
                }
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }


        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
                openFileDialog.Title = "Выберите файл с данными";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (tabControl1.SelectedTab == tabPageBooks_KVA) // Книги
                        {
                            booksFilePath = openFileDialog.FileName;
                            LoadBooksFromCSV(booksFilePath);

                            
                            booksDataTable = booksDataTableFull.Copy();
                            dataGridView1.DataSource = booksDataTable;
                        }
                        else // Читатели
                        {
                            readersFilePath = openFileDialog.FileName;
                            LoadReadersFromCSV(readersFilePath);

                            
                            readersDataTable = readersDataTableFull.Copy();
                            dataGridView2.DataSource = readersDataTable;
                        }

                        MessageBox.Show("Файл успешно загружен!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки файла: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Обработчик для сохранения файла
        private void toolStripSaveFile_KVA_Click(object sender, EventArgs e)
        {
            SaveDataToFiles();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ToolStripAbout_KVA_Click(object sender, EventArgs e)
        {
            var formAbt = new FormAbout();
            formAbt.ShowDialog();
        }

        //

        private void ToolStripMenuFunc_KVA_CLick(object sender, EventArgs e)
        {
            var formGraph = new FormGraph(booksDataTableFull);
            formGraph.ShowDialog();
        }

        private void ToolStripGuide_KVA_CLick(object sender, EventArgs e)
        {
            var formGuide = new FormGuide();
            formGuide.ShowDialog();
        }



        // Поиск и фильтры
        
        private void FilterDataByComboBox()
        {
            try
            {
                if (tabControl1.SelectedTab == tabPageBooks_KVA) // Работаем с книгами
                {
                    if (comboBoxFiltr_KVA.SelectedItem == null || comboBoxFiltr_KVA.SelectedItem.ToString() == "Все")
                    {
                        // Если выбрано "Все" или ничего не выбрано, показываем все данные
                        dataGridView1.DataSource = booksDataTableFull;
                        return;
                    }

                    // Получаем выбранный фильтр
                    string filterValue = comboBoxFiltr_KVA.SelectedItem.ToString();

                    // Применяем фильтр в зависимости от значения
                    DataTable filteredTable = booksDataTableFull.Clone();

                    foreach (DataRow row in booksDataTableFull.Rows)
                    {
                        bool includeRow = false;

                        // Варианты фильтров
                        switch (filterValue)
                        {
                            case "Новые издания":
                                if (row["Новое издание"] is true)
                                    includeRow = true;
                                break;

                            case "Старые издания":
                                if (row["Новое издание"] is false)
                                    includeRow = true;
                                break;

                            case "Дорогие книги (от 700)":
                                if (Convert.ToDecimal(row["Цена"]) >= 700)
                                    includeRow = true;
                                break;

                            case "Дешевые книги (до 500)":
                                if (Convert.ToDecimal(row["Цена"]) <= 500)
                                    includeRow = true;
                                break;

                            case "Классика (до 1900 года)":
                                if (Convert.ToInt32(row["Год издания"]) < 1900)
                                    includeRow = true;
                                break;
                        }

                        if (includeRow)
                        {
                            filteredTable.ImportRow(row);
                        }
                    }

                    dataGridView1.DataSource = filteredTable;
                }
                else if (tabControl1.SelectedTab == tabPageReaders_KVA) // читатели
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при фильтрации данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Поиск данных
        private void SearchDataByTextBox()
        {
            try
            {
                string searchText = textBoxSearch_KVA.Text.Trim();

                if (tabControl1.SelectedTab == tabPageBooks_KVA)
                {
                    if (string.IsNullOrEmpty(searchText))
                    {
                        // Если поле поиска пустое, показываем все данные
                        dataGridView1.DataSource = booksDataTableFull;
                        return;
                    }

                    // Создаем фильтр
                    DataTable searchTable = booksDataTableFull.Clone();

                    foreach (DataRow row in booksDataTableFull.Rows)
                    {
                        // Проверяем
                        bool found = row["Автор"].ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    row["Название"].ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    row["Описание"].ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    row["Год издания"].ToString().Contains(searchText) ||
                                    row["Цена"].ToString().Contains(searchText);

                        if (found)
                        {
                            searchTable.ImportRow(row);
                        }
                    }

                    dataGridView1.DataSource = searchTable;

                    // Если результатов нет, показываем сообщение
                    if (searchTable.Rows.Count == 0)
                    {
                        MessageBox.Show($"По запросу '{searchText}' ничего не найдено.", "Результаты поиска",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (tabControl1.SelectedTab == tabPageReaders_KVA)
                {

                    string searchText2 = textBox2.Text.Trim();
                    if (string.IsNullOrEmpty(searchText2))
                    {
                        dataGridView2.DataSource = readersDataTableFull;
                        return;
                    }

                    DataTable searchTable2 = readersDataTableFull.Clone();

                    foreach (DataRow row in readersDataTableFull.Rows)
                    {
                        bool found = row["ФИО"].ToString().IndexOf(searchText2, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    row["Номер билета"].ToString().IndexOf(searchText2, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    row["Адрес"].ToString().IndexOf(searchText2, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    row["Телефон"].ToString().Contains(searchText2);

                        if (found)
                        {
                            searchTable2.ImportRow(row);
                        }
                    }

                    dataGridView2.DataSource = searchTable2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //---
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

            }
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

            }
        }
    }
}