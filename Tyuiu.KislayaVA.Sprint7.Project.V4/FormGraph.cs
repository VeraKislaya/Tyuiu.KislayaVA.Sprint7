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
        private DataTable booksData;

        public FormGraph(DataTable booksData)
        {
            InitializeComponent();
            this.booksData = booksData;
        }

        public FormGraph() : this(null)
        {
        }

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

        private void BuildPriceChart()
        {
            try
            {
                // Очистка данных
                chart1.Series.Clear();

                //
                if (chart1.ChartAreas.Count == 0)
                {
                    chart1.ChartAreas.Add(new ChartArea("ChartArea1"));
                }

                ChartArea chartArea = chart1.ChartAreas[0];

                // Настраиваем оси графика
                chartArea.AxisX.Title = "Названия книг";
                chartArea.AxisY.Title = "Цена (руб.)";
                chartArea.AxisX.Interval = 10;
                chartArea.AxisY.Minimum = 0;



                // Настраиваем угол подписей для лучшей читаемости
                chartArea.AxisX.LabelStyle.Angle = -45;
                chartArea.AxisX.LabelStyle.Font = new Font("Arial", 8);

                // Создаем серию для графика
                Series priceSeries = new Series("Цены книг");
                priceSeries.ChartType = SeriesChartType.Column;
                priceSeries.Color = Color.SteelBlue;
                priceSeries.BorderColor = Color.DarkBlue;
                priceSeries.BorderWidth = 2;
                priceSeries.IsValueShownAsLabel = true;
                priceSeries.LabelFormat = "N0 руб.";
                priceSeries.XValueType = ChartValueType.String;

                // Считаем статистику
                decimal maxPrice = 0;
                decimal minPrice = decimal.MaxValue;
                decimal totalPrice = 0;
                int bookCount = 0;

                // Заполняем данные графика
                foreach (DataRow row in booksData.Rows)
                {
                    if (row["Название"] != DBNull.Value && row["Цена"] != DBNull.Value)
                    {
                        string bookTitle = row["Название"].ToString();
                        decimal price = Convert.ToDecimal(row["Цена"]);

                        // Форматируем название для отображения (обрезаем если слишком длинное)
                        string displayTitle = bookTitle;
                        if (displayTitle.Length > 15)
                        {
                            displayTitle = displayTitle.Substring(0, 15) + "...";
                        }

                        // Добавляем точку на график
                        DataPoint point = new DataPoint();
                        point.SetValueXY(displayTitle, price);
                        point.Label = price.ToString("N0");
                        point.ToolTip = $"{bookTitle}\nЦена: {price:N0} руб.";
                        priceSeries.Points.Add(point);

                        // Собираем статистику
                        maxPrice = Math.Max(maxPrice, price);
                        minPrice = Math.Min(minPrice, price);
                        totalPrice += price;
                        bookCount++;
                    }
                }

                // Добавляем серию на график
                chart1.Series.Add(priceSeries);

                // Вычисляем среднюю цену
                decimal avgPrice = bookCount > 0 ? totalPrice / bookCount : 0;

                // Отображаем статистику в label
                label1.Text = $"Статистика цен книг:\n" +
                             $"Всего книг: {bookCount}\n" +
                             $"Максимальная цена: {maxPrice:N0} руб.\n" +
                             $"Минимальная цена: {minPrice:N0} руб.\n" +
                             $"Средняя цена: {avgPrice:N2} руб.\n" +
                             $"Общая стоимость: {totalPrice:N0} руб.";

                // Настраиваем заголовок графика
                chart1.Titles.Clear();
                chart1.Titles.Add("График цен книг");
                chart1.Titles[0].Font = new Font("Arial", 12, FontStyle.Bold);

                // Добавляем сетку для лучшей читаемости
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

        // Метод для обновления графика с новыми данными
        public void UpdateChartData(DataTable newBooksData)
        {
            booksData = newBooksData;
            BuildPriceChart();
        }
    }
}