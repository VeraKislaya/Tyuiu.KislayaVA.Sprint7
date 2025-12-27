using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Tyuiu.KislayaVA.Sprint7.Project.V4
{
    public partial class FormGraph : Form
    {
        // Для данных кнги
        
        private DataTable booksData;

        // Получаем данные о книгах
        public FormGraph(DataTable booksData)
        {
            InitializeComponent();
            this.booksData = booksData;
        }

        
        // чтоб все работало
        public FormGraph() : this(null)
        {

        }

        // Если чета пошло не так
        private void FormGraph_Load(object sender, EventArgs e)
        {
            if (booksData == null || booksData.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для построения графика", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BuildPriceChart();
        }

        // Составляем график
        private void BuildPriceChart()
        {
            try
            {
                // Очистка данных
                chartStats_KVA.Series.Clear();
                if (chartStats_KVA.ChartAreas.Count == 0)
                {
                    chartStats_KVA.ChartAreas.Add(new ChartArea("ChartArea1"));
                }

                ChartArea chartArea = chartStats_KVA.ChartAreas[0];


                chartArea.AxisX.Title = "Названия книг";
                chartArea.AxisY.Title = "Цена (руб.)";
                chartArea.AxisX.Interval = 10;
                chartArea.AxisY.Minimum = 0;


                // Тут создается серия цен книг
                Series priceSeries = new Series("Цены книг");
                priceSeries.ChartType = SeriesChartType.Column;
                priceSeries.Color = Color.SteelBlue;
                priceSeries.BorderColor = Color.DarkBlue;
                priceSeries.BorderWidth = 2;
                priceSeries.IsValueShownAsLabel = true;
                priceSeries.LabelFormat = "N0 руб.";
                priceSeries.XValueType = ChartValueType.Int32;

                // Значения статистики по умолчанию
                decimal maxPrice = 0;
                decimal minPrice = decimal.MaxValue;
                decimal totalPrice = 0;
                int bookCount = 0;

                // Заполняем данные графика
                int pointIndex = 2;

                foreach (DataRow row in booksData.Rows)
                {
                    if (row["Название"] != DBNull.Value && row["Цена"] != DBNull.Value)
                    {
                        string bookTitle = row["Название"].ToString();
                        decimal price = Convert.ToDecimal(row["Цена"]);



                        DataPoint point = new();
                        point.SetValueXY(pointIndex, price);
                        point.AxisLabel = bookTitle; // Отображаем название книги на Х 
                        point.Label = price.ToString("N0");
                        point.ToolTip = $"{bookTitle}\nЦена: {price:N0} руб.\nПорядковый номер: {pointIndex}";
                        point.LegendText = bookTitle;
                        priceSeries.Points.Add(point);
                        pointIndex += 2;

                        // Сбор статистических данных
                        maxPrice = Math.Max(maxPrice, price);
                        minPrice = Math.Min(minPrice, price);
                        totalPrice += price;
                        bookCount++;
                    }
                }

                // Настраиваем ось X для отображения названий книг
                chartArea.AxisX.CustomLabels.Clear();
                pointIndex = 2;
                foreach (DataRow row in booksData.Rows)
                {
                    if (row["Название"] != DBNull.Value)
                    {
                        string bookTitle = row["Название"].ToString();
                        string displayTitle = bookTitle;

                        pointIndex += 2;
                    }
                }



                chartStats_KVA.Series.Add(priceSeries);

                // Средняя цена
                decimal avgPrice = bookCount > 0 ? totalPrice / bookCount : 0;

                // Текстовая статистика
                labelStatis_KVA.Text = $"Статистика цен книг:\n" +
                             $"Всего книг: {bookCount}\n" +
                             $"Максимальная цена: {maxPrice:N0} руб.\n" +
                             $"Минимальная цена: {minPrice:N0} руб.\n" +
                             $"Средняя цена: {avgPrice:N2} руб.\n" +
                             $"Общая стоимость: {totalPrice:N0} руб.";

                // Заголовок для графика
                chartStats_KVA.Titles.Clear();
                chartStats_KVA.Titles.Add("График цен книг");
                chartStats_KVA.Titles[0].Font = new Font("Arial", 12, FontStyle.Bold);

                // Сетка
                chartArea.AxisX.MajorGrid.Enabled = true;
                chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
                chartArea.AxisY.MajorGrid.Enabled = true;
                chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при построении графика: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обновление
        public void UpdateChartData(DataTable newBooksData)
        {
            // Получаем данные книг
            
            booksData = newBooksData;

            // Очистка графика чтоб наверняка
            chartStats_KVA.Series.Clear();
            if (chartStats_KVA.ChartAreas.Count > 0)
            {
                chartStats_KVA.ChartAreas[0].AxisX.CustomLabels.Clear();
            }

            // Перестроение
            BuildPriceChart();
            chartStats_KVA.Invalidate();
            chartStats_KVA.Update();
            Refresh();
        }

        // Кнопка для закрытия окна (типо удобно)
        private void buttonCloseStats_KVA_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}