using Microsoft.EntityFrameworkCore;

using System.Data;

using Npgsql;
using OxyPlot;
using OxyPlot.Series;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Curs_BD_v0._1
{
    public partial class Form2 : Form
    {
        private void Form2_Load(object sender, EventArgs e)
        {
            string con = "Host=localhost;Username=postgres;Password=5228;Database=postgres";
            NpgsqlConnection nc = new NpgsqlConnection(con);
            nc.Open();
            Random random = new Random();
            NpgsqlDataAdapter ats = new NpgsqlDataAdapter($"""SELECT * FROM inner_join_ats""", nc);

            nc.Close();
            DataSet dt = new DataSet();
            ats.Fill(dt);

            dataGridView1.DataSource = dt.Tables[0];
            NpgsqlDataAdapter subscriber = new NpgsqlDataAdapter($"""SELECT id_subscriber, fullname, address_subscriber, area FROM inner_join_subscriber""", nc);

            nc.Close();
            DataSet dt1 = new DataSet();
            subscriber.Fill(dt1);

            dataGridView2.DataSource = dt1.Tables[0];
            Count_Rows_TextBox.Text = (dataGridView1.RowCount - 1).ToString();
            Count_Rows_2_TextBox.Text = (dataGridView2.RowCount - 1).ToString();

            dataGridView1.RowHeadersWidth = 30;
            dataGridView1.Columns[0].Width = 58; dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].Width = 160; dataGridView1.Columns[1].HeaderText = "Название";
            dataGridView1.Columns[2].Width = 176; dataGridView1.Columns[2].HeaderText = "Район";
            dataGridView1.Columns[3].Width = 190; dataGridView1.Columns[3].HeaderText = "Адрес";
            dataGridView1.Columns[4].Width = 100; dataGridView1.Columns[4].HeaderText = "Год открытия";
            dataGridView1.Columns[5].Width = 70; dataGridView1.Columns[5].HeaderText = "Статус";
            dataGridView1.Columns[6].Width = 118; dataGridView1.Columns[6].HeaderText = "Лицензия";

            dataGridView2.RowHeadersWidth = 30;
            dataGridView2.Columns[0].Width = 58; dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].Width = 160; dataGridView2.Columns[1].HeaderText = "ФИО";
            dataGridView2.Columns[2].Width = 196; dataGridView2.Columns[2].HeaderText = "Адрес";
            dataGridView2.Columns[3].Width = 170; dataGridView2.Columns[3].HeaderText = "Район";

            string[] name_ats = { "МТС", "Билайн", "Мегафон", "Теле2", "Йота" ,"Ростелеком", "ВымпелКом",
                    "Таттелеком", "Дом.ру","Байкалвестком", "Интертелеком", "Киевстар", "Лайфселл", "Нетология", "Ого!", "Смартс",
                    "Триколор ТВ", "Укртелеком", "Фастнет", "Хоум Нет", "Эрикссон", "Яндекс.Мобильный", "Актив",
                    "Безлимитный интернет", "Вимакс", "Глобус Телеком", "Дальсвязь",
                    "Енисейтелеком", "Железнодорожная сотовая связь", "Зенит-Телеком", "Интеркроссинг",
                    "Комстар-Регионы", "Локо-мобиль", "Максимум Телеком", "Невафон", "Оренбург Мобайл", "Пенза-Мобайл",
                    "Радио-Телефония", "Связной Телеком", "ТрансТелеКом", "Уралсвязьинформ", "Фрегат Телеком",
                    "Хабаровск-Мобайл", "Центральный Телеграф", "Черкизово-Мобайл", "Шторм Телеком", "Энергия Телеком", "Юнион Телеком" };

            string[] street = { "Проезд Ленина", "Улица Гагарина", "Проспект Мира", "Переулок Лесной", "Шоссе Космонавтов", "Набережная Волги", "Бульвар Центральный",
                "Аллея Парковая", "Квартал Солнечный", "Тупик Зеленый", "Площадь Революции", "Просека Садовая", "Переход Мостовой", "Улица Заводская", "Проезд Транспортный",
                "Шоссе Энтузиастов", "Набережная Речная", "Бульвар Городской", "Аллея Цветочная", "Квартал Новый", "Тупик Северный", "Площадь Ленинская", "Просека Луговая",
                "Переход Железнодорожный", "Улица Ленинградская", "Проезд Восточный", "Шоссе Строителей", "Набережная Морская", "Бульвар Победы", "Аллея Дубравная", "Квартал Рабочий",
                "Тупик Южный", "Площадь Советская", "Просека Октябрьская", "Переход Красноармейский", "Улица Садовый", "Проезд Западный", "Шоссе Лесное", "Набережная Озерная",
                "Бульвар Комсомольский", "Аллея Березовая", "Квартал Лесной", "Тупик Центральный", "Площадь Пушкина", "Просека Речная", "Переход Строительный", "Улица Молодежная" };

            string[] names = { "Абрамова Елена Игоревна", "Баранова Анна Александровна", "Васильев Дмитрий Иванович", "Горбунова Ольга Сергеевна", "Данилов Андрей Петрович", "Ефимова Наталья Александровна", "Жуков Михаил Владимирович",
                "Зайцева Екатерина Андреевна", "Иванов Александр Сергеевич", "Козлова Мария Дмитриевна", "Лебедев Иван Александрович", "Макарова Елена Викторовна", "Новиков Сергей Васильевич", "Орлова Анна Николаевна", "Петров Игорь Андреевич",
                "Романова Ольга Владимировна", "Смирнов Алексей Игоревич", "Тарасова Елена Сергеевна", "Ушаков Дмитрий Александрович", "Федорова Анна Дмитриевна", "Харитонов Иван Павлович", "Цветкова Ольга Васильевна",
                "Чернов Александр Михайлович", "Шестакова Наталья Ивановна", "Щербаков Денис Андреевич", "Яковлева Елена Александровна", "Андреева Анна Сергеевна", "Белова Ольга Ивановна", "Волков Андрей Владимирович",
                "Григорьева Екатерина Петровна", "Дмитриев Алексей Викторович", "Егорова Мария Сергеевна", "Журавлев Александр Николаевич", "Зайцев Иван Андреевич", "Ильина Ольга Александровна", "Калинина Наталья Дмитриевна",
                "Кузнецов Артем Сергеевич", "Лапина Екатерина Александровна", "Михайлов Сергей Иванович", "Никитина Анна Владимировна", "Осипова Елена Александровна", "Павлова Ольга Викторовна", "Рыбаков Дмитрий Андреевич",
                "Сидорова Анастасия Сергеевна", "Тихомиров Сергей Петрович", "Устинова Екатерина Дмитриевна", "Фадеев Илья Александрович", "Хохлова Наталья Васильевна", "Чернышева Ольга Игоревна", "Широков Андрей Валерьевич",
                "Щербина Мария Александровна"};



            using (var context = new ApplicationContext())
            {

                // --------- ЗАПОЛНЕНИЕ ТАБЛИЦЫ SUBSCRIBER ---------

                /*var image = new Bitmap("1.jpg");
                byte[] imageBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageBytes = ms.ToArray();
                }
                int k = 0;
                var dt_ats = context.subscriber.ToList();
                for (int i = 0; i < 1000; i++)
                {

                    var new_subscriber = new subscriber();
                    new_subscriber.id_subscriber = i + 1;
                    k = random.Next(1, 4);
                    if (k == 2)
                    {

                        new_subscriber.benefit_document = imageBytes;
                        new_subscriber.id_benefit = random.Next(1, 7);
                    }
                    else
                    {

                        new_subscriber.benefit_document = null;
                    }
                    new_subscriber.fullname = names[random.Next(1, 46)];
                    int dd = random.Next(53, 104);
                    if (dd != 101 && dd != 99)
                        new_subscriber.id_ats = dd;
                    else
                        new_subscriber.id_ats = 60;

                    new_subscriber.address_subscriber = street[random.Next(1, 46)] + ", " + random.Next(1, 200) + ", кв " + random.Next(1, 100);
                    new_subscriber.id_area = random.Next(1, 10);

                    new_subscriber.id_social_status = random.Next(1, 8);
                    context.subscriber.Add(new_subscriber);
                    context.SaveChanges();
                }*/

                //var dt_ats = context.subscriber.ToList();
                //dataGridView2.DataSource = dt_ats.ToList();



                //--------- ЗАПОЛНЕНИЕ ТАБЛИЦЫ ATS ---------

                /*for (int i = 0; i < 46; i++)
                {

                    var ats = new ATS();

                    ats.title = name_ats[i];
                    
                    ats.id_area = random.Next(1, 10);
                    ats.address = street[i] + ", " + random.Next(1, 200);
                    ats.year_of_opening = random.Next(1960,2022);
                    if (i % 2 == 0)
                        ats.status = true;
                    else
                        ats.status = false;
                    string randomString = "";
                    

                    for (int d = 0; d < 5; d++)
                    {
                        randomString += random.Next(0, 10).ToString();
                        randomString += ((char)random.Next('a', 'z' + 1)).ToString();
                    }

                    ats.license_to_provide_services = randomString;
                    context.ats.Add(ats);
                    context.SaveChanges();
                }*/





                // --------- ВЫВОД ФОТО ПО ЗАПРОСУ В PICTUREBOX ---------

                /*using (NpgsqlCommand command = new NpgsqlCommand("SELECT benefit_document FROM public.\"Subscriber\" \r\nWHERE public.\"Subscriber\".id_subscriber = 141", nc))
                {
                    command.Parameters.AddWithValue("@id", 141);
                    byte[] imageBytes2 = (byte[])command.ExecuteScalar();
                    // использовать массив байтов с изображением
                    MemoryStream ms = new MemoryStream(imageBytes2);
                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);


                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;


                    pictureBox1.Image = img;
                }*/




                //--------- ЗАПОЛНЕНИЕ ТАБЛИЦЫ BENEFIT ---------

                /*for (int i = 53; i < 104; i++)
                {
                    if (i == 101 || i == 99)
                        continue;
                    int j = random.Next(1, 6);
                    for (int d = 1; d <= j; d++)
                    {
                        var benefit1 = new benefit();
                        benefit1.id_ats = i;
                        benefit1.id_benefit = d;
                        benefit1.id_social_status = random.Next(1, 8);
                        benefit1.id_type_of_payment = random.Next(1, 6);
                        benefit1.coef = Math.Round(random.NextDouble(), 1);

                        context.benefit1.Add(benefit1);
                        context.SaveChanges();

                    }


                }*/



                //--------- ЗАПОЛНЕНИЕ ТАБЛИЦЫ CALL ---------

                /*nc.Open();
                for (int i = 1; i < 15000; i++)
                {

                    var call = new call();

                    call.id_rate = random.Next(1, 5);
                    call.id_subscriber = random.Next(1, 947);
                    call.id_city = random.Next(1, 37);
                    call.call_duration = random.Next(1, 7200);
                    random = new Random();
                    call.call_date = new DateTime(random.Next(1950, 2023), random.Next(1, 13), random.Next(1, 29));
                    call.number_phone_friend = "+" + random.Next(100000, 999999).ToString() + random.Next(10000, 99999).ToString();

                    NpgsqlCommand search_coefficient = new NpgsqlCommand($"""SELECT "coefficient" FROM rate WHERE id_rate = {call.id_rate}""", nc);
                    call.cost = Convert.ToInt32(search_coefficient.ExecuteScalar()) * (call.call_duration / 60);

                    NpgsqlCommand search_country = new NpgsqlCommand($"""SELECT "id_country" FROM city WHERE id_city = {call.id_city}""", nc);
                    int id_country = Convert.ToInt32(search_country.ExecuteScalar());

                    if (id_country == 1)
                    {
                        try
                        {
                            NpgsqlCommand search_benefit = new NpgsqlCommand($"""SELECT coef FROM inner_join_subscriber WHERE id_subscriber = {call.id_subscriber}""", nc);
                            int coef = Convert.ToInt32(search_benefit.ExecuteScalar());
                            call.cost *= coef;
                        }
                        catch (Exception ex) { }
                    }
                    context.call.Add(call);
                    context.SaveChanges();
                }*/


                /*var dt_ats = context.ats.ToList();
                dataGridView1.DataSource = dt_ats.ToList();

                var dt_subscriber = context.subscriber.ToList();
                dataGridView2.DataSource = dt_subscriber.ToList();
                nc.Close();*/

            }


        }
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            /*Form3 form3 = new Form3();
            form3.ShowDialog();*/

            //Добавление нового
            string con = "Host=localhost;Username=postgres;Password=5228;Database=postgres";
            NpgsqlConnection nc = new NpgsqlConnection(con);
            nc.Open();
            if (title_ats_textBox.Text != "" && area_ats_comboBox.Text != "" &&
                address_ats_textBox.Text != "" && year_of_opening_ats_numericUpDown.Value != 0 && status_ats_comboBox.Text != "" &&
                license_ats_textBox.Text != "")
            {
                NpgsqlCommand search_area = new NpgsqlCommand($"""SELECT id_area FROM area WHERE areas_list = '{area_ats_comboBox.Text}'""", nc);
                int id_area = Convert.ToInt32(search_area.ExecuteScalar());

                bool statusBool;
                if (status_ats_comboBox.Text == "Гос") statusBool = true;
                else statusBool = false;

                try
                {
                    NpgsqlDataAdapter add_new_Rental = new NpgsqlDataAdapter($"""SELECT add_new_ats('{title_ats_textBox.Text}', {id_area}, '{address_ats_textBox.Text}', {year_of_opening_ats_numericUpDown.Value}, {statusBool}, '{license_ats_textBox.Text}')""", nc);
                    DataSet dt_add = new DataSet();
                    add_new_Rental.Fill(dt_add);
                }
                catch (PostgresException ex)
                {
                    MessageBox.Show(
                    caption: "Внимание!",
                    text: ex.Message,
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information);
                }

                catch (Exception ex) { }

                NpgsqlDataAdapter ats = new NpgsqlDataAdapter($"""SELECT * FROM inner_join_ats""", nc);
                nc.Close();
                DataSet dt = new DataSet();
                ats.Fill(dt);
                dataGridView1.DataSource = dt.Tables[0];
                Count_Rows_TextBox.Text = (dataGridView1.RowCount - 1).ToString();
            }
            else
            {

                MessageBox.Show(
                    caption: "Внимание!",
                    text: "Не все обязательные параметры были заполнены",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information);

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            string con = "Host=localhost;Username=postgres;Password=5228;Database=postgres";
            NpgsqlConnection nc = new NpgsqlConnection(con);
            nc.Open();
            if (dataGridView1.SelectedRows.Count > 0)
            {



            }

            nc.Close();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            button9.Visible = true;
            textBox2.Text = "";
            textBox11.Text = "";
            textBox5.Text = "";
            comboBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox4.Text = "";
            pictureBox2.Image = null;

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            button9.Visible = false;
            if (textBox11.Text != "" && textBox5.Text != "" && comboBox3.Text != "" && comboBox1.Text != "" && comboBox4.Text != "")
            {
                string con = "Host=localhost;Username=postgres;Password=5228;Database=postgres";
                NpgsqlConnection nc = new NpgsqlConnection(con);
                nc.Open();
                int id_benefit = 0;

                NpgsqlCommand search_area = new NpgsqlCommand($"""SELECT id_area FROM area WHERE areas_list = '{comboBox3.Text}'""", nc);
                int id_area = Convert.ToInt32(search_area.ExecuteScalar());
                NpgsqlCommand search_ats = new NpgsqlCommand($"""SELECT id_ats FROM ats WHERE title = '{comboBox1.Text}'""", nc);

                int id_ats = Convert.ToInt32(search_ats.ExecuteScalar());
                if (comboBox2.Text != "")
                {
                    NpgsqlCommand search_benefit = new NpgsqlCommand($"""SELECT id_benefit FROM benefits WHERE benefit = '{comboBox2.Text}'""", nc);
                    id_benefit = Convert.ToInt32(search_benefit.ExecuteScalar());
                }

                byte[] imageBytes = null;
                if (pictureBox2.Image != null)
                {

                    var image = new Bitmap(pictureBox2.Image);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        imageBytes = ms.ToArray();
                    }
                }

                nc.Close();
                nc.Open();
                NpgsqlCommand search_social_status = new NpgsqlCommand($"""SELECT id_social_status FROM "Social_status" WHERE social_status = '{comboBox4.Text}'""", nc);
                int id_social_status = Convert.ToInt32(search_social_status.ExecuteScalar());
                try
                {

                    NpgsqlDataAdapter add_new_subscriber = new NpgsqlDataAdapter($"""SELECT add_new_subscriber('{textBox11.Text}',{id_ats}, '{id_benefit}','{textBox5.Text}', {id_social_status}, '{imageBytes}', {id_area})""", nc);

                    DataSet dt_add = new DataSet();
                    add_new_subscriber.Fill(dt_add);

                }
                catch (PostgresException ex)
                {

                    MessageBox.Show(
                    caption: "Внимание!",
                    text: ex.Message,
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information);
                }
                catch (Exception ex) { }
                NpgsqlDataAdapter subscriber = new NpgsqlDataAdapter($"""SELECT id_subscriber, fullname, address_subscriber, area FROM inner_join_subscriber""", nc);

                nc.Close();
                DataSet dt1 = new DataSet();
                subscriber.Fill(dt1);

                dataGridView2.DataSource = dt1.Tables[0];
            }
            else
            {
                MessageBox.Show(
                    caption: "Внимание!",
                    text: "Не все обязательные параметры были заполнены",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new()
            {
                Title = "Выберите изображение для загрузки",
                Filter = "Файлы изображений|*.jpg;*.png",
                CheckFileExists = true
            };
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            System.Drawing.Image pic;
            try
            {
                pic = System.Drawing.Image.FromFile(dialog.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    caption: "Ошибка чтения картинки",
                    text: "При чтении картинки произошла ошибка! Возможно, файл повреждён.",
                    icon: MessageBoxIcon.Error,
                    buttons: MessageBoxButtons.OK
                );
                return;
            }

            pictureBox2.Image = pic;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {

                string id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();

                string con = "Host=localhost;Username=postgres;Password=5228;Database=postgres";
                NpgsqlConnection nc = new NpgsqlConnection(con);
                nc.Open();


                try
                {

                    NpgsqlDataAdapter delete_subscriber = new NpgsqlDataAdapter($"""SELECT delete_subscriber({id})""", nc);

                    DataSet dt_delete = new DataSet();
                    delete_subscriber.Fill(dt_delete);

                }
                catch (PostgresException ex)
                {

                    MessageBox.Show(
                    caption: "Внимание!",
                    text: ex.Message,
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { }

                NpgsqlDataAdapter ats = new NpgsqlDataAdapter($"""SELECT id_subscriber, fullname, address_subscriber, area FROM inner_join_subscriber""", nc);
                DataSet dt = new DataSet();
                ats.Fill(dt);
                dataGridView2.DataSource = dt.Tables[0];
                Count_Rows_2_TextBox.Text = (dataGridView2.RowCount - 1).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {

                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                string con = "Host=localhost;Username=postgres;Password=5228;Database=postgres";
                NpgsqlConnection nc = new NpgsqlConnection(con);
                nc.Open();


                try
                {

                    NpgsqlDataAdapter delete_ats = new NpgsqlDataAdapter($"""SELECT delete_ats({id})""", nc);

                    DataSet dt_delete = new DataSet();
                    delete_ats.Fill(dt_delete);

                }
                catch (PostgresException ex)
                {

                    MessageBox.Show(
                    caption: "Внимание!",
                    text: ex.Message,
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { }


                nc.Close();

                NpgsqlDataAdapter ats = new NpgsqlDataAdapter($"""SELECT * FROM inner_join_ats""", nc);
                DataSet dt = new DataSet();
                ats.Fill(dt);
                dataGridView1.DataSource = dt.Tables[0];
                Count_Rows_TextBox.Text = (dataGridView1.RowCount - 1).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string con = "Host=localhost;Username=postgres;Password=5228;Database=postgres";
            NpgsqlConnection nc = new NpgsqlConnection(con);
            nc.Open();
            if (dataGridView1.CurrentRow != null)
            {


                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                if (title_ats_textBox.Text != "")
                {

                    NpgsqlDataAdapter ats = new NpgsqlDataAdapter($"""SELECT edit_title_ats ({id},'{title_ats_textBox.Text}')""", nc);


                    try
                    {
                        DataSet dt_edit = new DataSet();
                        ats.Fill(dt_edit);
                    }
                    catch (Exception ex) { }
                }


            }
            NpgsqlDataAdapter ats2 = new NpgsqlDataAdapter($"""SELECT * FROM inner_join_ats""", nc);
            DataSet dt = new DataSet();
            ats2.Fill(dt);
            dataGridView1.DataSource = dt.Tables[0];
            Count_Rows_TextBox.Text = (dataGridView1.RowCount - 1).ToString();
            nc.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string con = "Host=localhost;Username=postgres;Password=5228;Database=postgres";
            NpgsqlConnection nc = new NpgsqlConnection(con);
            nc.Open();

            if (button2.Visible == true)
            {
                button1.Visible = false;
                button2.Visible = false;
                button7.Visible = false;
                button13.Visible = false;
                button14.Visible = false;

                comboBox5.Visible = true;
                comboBox6.Visible = true;
                button10.Visible = true;
            }





        }

        private void button10_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button7.Visible = true;
            button13.Visible = true;
            button14.Visible = true;

            comboBox5.Visible = false;
            comboBox6.Visible = false;
            button10.Visible = false;


            string con = "Host=localhost;Username=postgres;Password=5228;Database=postgres";
            NpgsqlConnection nc = new NpgsqlConnection(con);
            nc.Open();

            NpgsqlCommand search_old_area = new NpgsqlCommand($"""SELECT id_area FROM area WHERE areas_list = '{comboBox5.Text}'""", nc);
            int id_old_area = Convert.ToInt32(search_old_area.ExecuteScalar());

            NpgsqlCommand search_new_area = new NpgsqlCommand($"""SELECT id_area FROM area WHERE areas_list = '{comboBox6.Text}'""", nc);
            int id_new_area = Convert.ToInt32(search_new_area.ExecuteScalar());

            NpgsqlDataAdapter ats2 = new NpgsqlDataAdapter($"""UPDATE "ats" SET id_area = {id_new_area} WHERE id_area = {id_old_area} """, nc);
            try
            {
                DataSet dt1 = new DataSet();
                ats2.Fill(dt1);
            }
            catch (Exception ex) { }
            Count_Rows_TextBox.Text = (dataGridView1.RowCount - 1).ToString();
            nc.Close();

            NpgsqlDataAdapter ats = new NpgsqlDataAdapter($"""SELECT * FROM inner_join_ats""", nc);
            DataSet dt = new DataSet();
            ats.Fill(dt);
            dataGridView1.DataSource = dt.Tables[0];
            Count_Rows_TextBox.Text = (dataGridView1.RowCount - 1).ToString();
        }

        private void button57_Click(object sender, EventArgs e)
        {
            string con = "Host=localhost;Username=postgres;Password=5228;Database=postgres";
            NpgsqlConnection nc = new NpgsqlConnection(con);
            nc.Open();
            int flag = 0;
            string Query = " WHERE ";


            if (id_ats_textBox.Text.Length > 0)
            {
                flag++;
                Query += "id_ats=" + id_ats_textBox.Text.ToString();

            }


            if (title_ats_textBox.Text.Length > 0)
            {
                if (flag > 0)
                    Query += "AND title ILIKE" + "'%" + title_ats_textBox.Text.ToString() + "%'";
                else
                    Query += "title ILIKE " + "'%" + title_ats_textBox.Text.ToString() + "%'";
                flag++;

            }


            if (address_ats_textBox.Text.Length > 0)
            {
                if (flag > 0)
                    Query += "AND address ILIKE " + "'%" + address_ats_textBox.Text.ToString() + "%'";
                else
                    Query += "address ILIKE " + "'%" + address_ats_textBox.Text.ToString() + "%'";
                flag++;

            }



            if (area_ats_comboBox.Text.Length > 0)
            {

                NpgsqlCommand search_area = new NpgsqlCommand($"""SELECT id_area FROM area WHERE areas_list = '{area_ats_comboBox.Text}'""", nc);
                int id_area = Convert.ToInt32(search_area.ExecuteScalar());


                if (flag > 0)
                    Query += " AND  areas_list='" + area_ats_comboBox.Text + "'";
                else
                    Query += " areas_list='" + area_ats_comboBox.Text + "'";
                flag++;

            }


            if (license_ats_textBox.Text.Length > 0)
            {

                if (flag > 0)
                    Query += " AND license_to_provide_services ILIKE" + "'%" + license_ats_textBox.Text.ToString() + "%'";
                else
                    Query += "license_to_provide_services ILIKE" + "'%" + license_ats_textBox.Text.ToString() + "%'";
                flag++;

            }


            if (flag > 0)
            {

                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM inner_join_ats" + Query + ";", con);

                DataSet dt = new DataSet();
                da.Fill(dt);
                dataGridView1.DataSource = dt.Tables[0];
            }

            else
            {

                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM inner_join_ats", con);

                DataSet dt = new DataSet();
                da.Fill(dt);
                dataGridView1.DataSource = dt.Tables[0];

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string con = "Host=localhost;Username=postgres;Password=5228;Database=postgres";
            NpgsqlConnection nc = new NpgsqlConnection(con);
            nc.Open();
            int flag = 0;
            string Query = " WHERE ";


            if (id_ats_textBox.Text.Length > 0)
            {
                flag++;
                Query += "id_ats=" + id_ats_textBox.Text.ToString();

            }


            if (title_ats_textBox.Text.Length > 0)
            {
                if (flag > 0)
                    Query += "AND title ILIKE" + "'%" + title_ats_textBox.Text.ToString() + "%'";
                else
                    Query += "title ILIKE " + "'%" + title_ats_textBox.Text.ToString() + "%'";
                flag++;

            }


            if (address_ats_textBox.Text.Length > 0)
            {
                if (flag > 0)
                    Query += "AND address ILIKE " + "'%" + address_ats_textBox.Text.ToString() + "%'";
                else
                    Query += "address ILIKE " + "'%" + address_ats_textBox.Text.ToString() + "%'";
                flag++;

            }


            if (area_ats_comboBox.Text.Length > 0)
            {

                NpgsqlCommand search_area = new NpgsqlCommand($"""SELECT id_area FROM area WHERE areas_list = '{area_ats_comboBox.Text}'""", nc);
                int id_area = Convert.ToInt32(search_area.ExecuteScalar());


                if (flag > 0)
                    Query += " AND  id_area=" + id_area;
                else
                    Query += " id_area=" + id_area;
                flag++;

            }


            if (license_ats_textBox.Text.Length > 0)
            {

                if (flag > 0)
                    Query += " AND license_to_provide_services ILIKE" + "'%" + license_ats_textBox.Text.ToString() + "%'";
                else
                    Query += "license_to_provide_services ILIKE" + "'%" + license_ats_textBox.Text.ToString() + "%'";
                flag++;

            }


            if (MessageBox.Show(
                     caption: "Внимание!",
                     text: "Будет удалено " + (dataGridView1.RowCount - 1).ToString() + " АТС. " + "Вы уверены, что хотите удалить эти данные?",
                     buttons: MessageBoxButtons.YesNo,
                     icon: MessageBoxIcon.Information) == DialogResult.Yes)
            {

                NpgsqlDataAdapter da = new NpgsqlDataAdapter("DELETE  FROM ats" + Query + ";", con);

                DataSet dt = new DataSet();
                da.Fill(dt);

            }


            NpgsqlDataAdapter ats = new NpgsqlDataAdapter($"""SELECT * FROM inner_join_ats""", nc);

            nc.Close();
            DataSet dt1 = new DataSet();
            ats.Fill(dt1);

            dataGridView1.DataSource = dt1.Tables[0];
            Count_Rows_TextBox.Text = (dataGridView1.RowCount - 1).ToString();



        }

        private void button15_Click(object sender, EventArgs e)
        {
            string con = "Host=localhost;Username=postgres;Password=5228;Database=postgres";
            NpgsqlConnection nc = new NpgsqlConnection(con);
            nc.Open();
            int flag = 0;
            string Query = " WHERE ";


            if (textBox2.Text.Length > 0)
            {
                flag++;
                Query += "id_subscriber=" + textBox2.Text.ToString();

            }


            if (textBox11.Text.Length > 0)
            {
                if (flag > 0)
                    Query += "AND fullname ILIKE" + "'%" + textBox11.Text.ToString() + "%'";
                else
                    Query += "fullname ILIKE " + "'%" + textBox11.Text.ToString() + "%'";
                flag++;

            }


            if (textBox5.Text.Length > 0)
            {
                if (flag > 0)
                    Query += "AND address_subscriber ILIKE " + "'%" + textBox5.Text.ToString() + "%'";
                else
                    Query += "address_subscriber ILIKE " + "'%" + textBox5.Text.ToString() + "%'";
                flag++;

            }



            if (comboBox3.Text.Length > 0)
            {

                /* NpgsqlCommand search_area = new NpgsqlCommand($"""SELECT id_area FROM area WHERE areas_list = '{comboBox3.Text}'""", nc);
                 int id_area = Convert.ToInt32(search_area.ExecuteScalar());*/


                if (flag > 0)
                    Query += " AND  area='" + comboBox3.Text + "'";
                else
                    Query += " area='" + comboBox3.Text + "'";
                flag++;

            }

            if (flag > 0)
            {
                NpgsqlDataAdapter subscriber = new NpgsqlDataAdapter("SELECT id_subscriber, fullname, address_subscriber, area FROM inner_join_subscriber" + Query + ";", con);

                nc.Close();
                DataSet dt1 = new DataSet();
                subscriber.Fill(dt1);

                dataGridView2.DataSource = dt1.Tables[0];
            }
            else
            {

                NpgsqlDataAdapter subscriber = new NpgsqlDataAdapter("SELECT id_subscriber, fullname, address_subscriber, area FROM inner_join_subscriber", con);

                nc.Close();
                DataSet dt1 = new DataSet();
                subscriber.Fill(dt1);

                dataGridView2.DataSource = dt1.Tables[0];

            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {

                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";

                string id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();

                string con = "Host=localhost;Username=postgres;Password=5228;Database=postgres";

                NpgsqlConnection nc = new NpgsqlConnection(con);
                nc.Open();
                try
                {


                    NpgsqlCommand search_photo = new NpgsqlCommand($"""SELECT benefit_document FROM "subscriber" WHERE id_subscriber = {id}""", nc);
                    search_photo.Parameters.AddWithValue("@id", id);

                    byte[] imageBytes2 = (byte[])search_photo.ExecuteScalar();
                    // использовать массив байтов с изображением
                    MemoryStream ms = new MemoryStream(imageBytes2);
                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                    pictureBox2.Image = img;
                }
                catch (Exception ex)
                {

                    pictureBox2.Image = null;
                }

                NpgsqlCommand search_ats = new NpgsqlCommand($"""SELECT title FROM inner_join_subscriber WHERE id_subscriber = {id}""", nc);
                comboBox1.Text = (search_ats.ExecuteScalar()).ToString();

                NpgsqlCommand search_social_status = new NpgsqlCommand($"""SELECT social_status FROM inner_join_subscriber WHERE id_subscriber = {id}""", nc);
                comboBox4.Text = (search_social_status.ExecuteScalar()).ToString();


                try
                {
                    NpgsqlCommand search_benefit = new NpgsqlCommand($"""SELECT benefit FROM inner_join_subscriber WHERE id_subscriber = {id}""", nc);
                    comboBox2.Text = (search_benefit.ExecuteScalar()).ToString();
                    NpgsqlCommand search_coef = new NpgsqlCommand($"""SELECT coef FROM inner_join_subscriber WHERE id_subscriber = {id}""", nc);
                    textBox1.Text = (search_coef.ExecuteScalar()).ToString();
                    NpgsqlCommand search_types = new NpgsqlCommand($"""SELECT types FROM inner_join_subscriber WHERE id_subscriber = {id}""", nc);
                    textBox4.Text = (search_types.ExecuteScalar()).ToString();

                }
                catch (Exception ex)
                {
                    textBox4.Text = "";
                    textBox1.Text = "";
                    comboBox2.Text = "";
                }

                try
                {
                    NpgsqlDataAdapter calls = new NpgsqlDataAdapter($"""SELECT * FROM inner_join_call WHERE id_sub = {id}""", con);
                    nc.Close();
                    DataSet dt2 = new DataSet();
                    calls.Fill(dt2);

                    dataGridView3.DataSource = dt2.Tables[0];
                    dataGridView3.RowHeadersWidth = 30;
                    dataGridView3.Columns[0].Width = 48;
                    dataGridView3.Columns[1].Width = 70;
                    dataGridView3.Columns[2].Width = 68;
                    dataGridView3.Columns[3].Width = 35;
                    dataGridView3.Columns[4].Width = 60;
                    dataGridView3.Columns[5].Width = 90;
                    dataGridView3.Columns[6].Width = 92;
                    dataGridView3.Columns[7].Width = 0;

                }
                catch (Exception ex) { }


            }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {


                string id = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();

                string con = "Host=localhost;Username=postgres;Password=5228;Database=postgres";

                NpgsqlConnection nc = new NpgsqlConnection(con);
                nc.Open();


                try
                {
                    NpgsqlCommand title_rate = new NpgsqlCommand($"""SELECT title_rate FROM inner_join_rate WHERE id_call = {id}""", nc);
                    textBox9.Text = (title_rate.ExecuteScalar()).ToString();
                    NpgsqlCommand start_call = new NpgsqlCommand($"""SELECT start_call FROM inner_join_rate WHERE id_call = {id}""", nc);
                    textBox7.Text = (start_call.ExecuteScalar()).ToString();
                    NpgsqlCommand end_call = new NpgsqlCommand($"""SELECT end_call FROM inner_join_rate WHERE id_call = {id}""", nc);
                    textBox8.Text = (end_call.ExecuteScalar()).ToString();
                    NpgsqlCommand coefficient = new NpgsqlCommand($"""SELECT coefficient FROM inner_join_rate WHERE id_call = {id}""", nc);
                    textBox10.Text = (coefficient.ExecuteScalar()).ToString();


                }
                catch (Exception ex)
                {
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string con = "Host=localhost;Username=postgres;Password=5228;Database=postgres";
            NpgsqlConnection nc = new NpgsqlConnection(con);
            nc.Open();
            PlotModel modelP1 = new PlotModel { Title = "Количество АТС" };

            dynamic seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

            NpgsqlCommand search_area1 = new NpgsqlCommand($""" SELECT COUNT(*) FROM "ats" WHERE "id_area"=1""", nc);
            int id_area1 = Convert.ToInt32(search_area1.ExecuteScalar());

            NpgsqlCommand search_area2 = new NpgsqlCommand($""" SELECT COUNT(*) FROM "ats" WHERE "id_area"=2""", nc);
            int id_area2 = Convert.ToInt32(search_area2.ExecuteScalar());

            NpgsqlCommand search_area3 = new NpgsqlCommand($""" SELECT COUNT(*) FROM "ats" WHERE "id_area"=3""", nc);
            int id_area3 = Convert.ToInt32(search_area3.ExecuteScalar());

            NpgsqlCommand search_area4 = new NpgsqlCommand($""" SELECT COUNT(*) FROM "ats" WHERE "id_area"=4""", nc);
            int id_area4 = Convert.ToInt32(search_area4.ExecuteScalar());

            NpgsqlCommand search_area5 = new NpgsqlCommand($""" SELECT COUNT(*) FROM "ats" WHERE "id_area"=5""", nc);
            int id_area5 = Convert.ToInt32(search_area5.ExecuteScalar());

            NpgsqlCommand search_area6 = new NpgsqlCommand($""" SELECT COUNT(*) FROM "ats" WHERE "id_area"=6""", nc);
            int id_area6 = Convert.ToInt32(search_area6.ExecuteScalar());

            NpgsqlCommand search_area7 = new NpgsqlCommand($""" SELECT COUNT(*) FROM "ats" WHERE "id_area"=7""", nc);
            int id_area7 = Convert.ToInt32(search_area7.ExecuteScalar());

            NpgsqlCommand search_area8 = new NpgsqlCommand($""" SELECT COUNT(*) FROM "ats" WHERE "id_area"=8""", nc);
            int id_area8 = Convert.ToInt32(search_area8.ExecuteScalar());

            NpgsqlCommand search_area9 = new NpgsqlCommand($""" SELECT COUNT(*) FROM "ats" WHERE "id_area"=9""", nc);
            int id_area9 = Convert.ToInt32(search_area9.ExecuteScalar());

            seriesP1.Slices.Add(new PieSlice("Будённовский", id_area1) { IsExploded = false, Fill = OxyColors.PaleVioletRed });
            seriesP1.Slices.Add(new PieSlice("Ворошиловский", id_area2) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Калининский", id_area3) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Киевский", id_area4) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Кировский", id_area5) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Куйбышевский", id_area6) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Ленинский", id_area7) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Петровский", id_area8) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Пролетарский", id_area9) { IsExploded = true });

            modelP1.Series.Add(seriesP1);
            plotView1.Model = modelP1;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            string con = "Host=localhost;Username=postgres;Password=5228;Database=postgres";

            NpgsqlConnection nc = new NpgsqlConnection(con);
            nc.Open();

            if (comboBox7.SelectedIndex == 0)
            {

                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM запрос_с_подзапросом_case", con);

                DataSet dt = new DataSet();
                da.Fill(dt);
                dataGridView4.DataSource = dt.Tables[0];
                textBox6.Text = "Вывод АТС, чьё количество абонентов выше среднего (популярное/ не популярное)";

            }

            if (comboBox7.SelectedIndex == 1)
            {

                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM итоговый_запрос_без_условия", con);

                DataSet dt = new DataSet();
                da.Fill(dt);
                dataGridView4.DataSource = dt.Tables[0];
                textBox6.Text = "Количество клиентов в каждом АТС";


            }

            if (comboBox7.SelectedIndex == 2)
            {

                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM итоговый_запрос_с_условием_на_груп", con);

                DataSet dt = new DataSet();
                da.Fill(dt);
                dataGridView4.DataSource = dt.Tables[0];
                textBox6.Text = "Вывод сделок, стоимость которых превышает среднюю стоимость";


            }

            if (comboBox7.SelectedIndex == 3)
            {

                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM итоговый_запрос_без_условия", con);

                DataSet dt = new DataSet();
                da.Fill(dt);
                dataGridView4.DataSource = dt.Tables[0];
                textBox6.Text = "Количество клиентов в каждом АТС";


            }

            if (comboBox7.SelectedIndex == 4)
            {

                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM итоговый_запрос_без_условия_всего_", con);

                DataSet dt = new DataSet();
                da.Fill(dt);
                dataGridView4.DataSource = dt.Tables[0];
                textBox6.Text = "Количество АТС по районам";


            }

            if (comboBox7.SelectedIndex == 5)
            {

                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM итоговый_запрос_с_условием_на_груп", con);

                DataSet dt = new DataSet();
                da.Fill(dt);
                dataGridView4.DataSource = dt.Tables[0];
                textBox6.Text = "Вывод сделок, стоимость которых превышает среднюю стоимость";


            }

            if (comboBox7.SelectedIndex == 6)
            {
                label13.Visible = true;
                label15.Visible = true;
                label16.Visible = true;
                label17.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                button21.Visible = true;
                panel3.Visible = true;
                comboBox8.Visible = true;
                textBox6.Text = "Вывод кол-ва звонков абонентов, АТС которых гос/не гос за указанный период";
            }

            if (comboBox7.SelectedIndex == 7)
            {

                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM запрос_на_запросе_по_принципу_и", con);

                DataSet dt = new DataSet();
                da.Fill(dt);
                dataGridView4.DataSource = dt.Tables[0];
                textBox6.Text = "Вывод количества городов, в которые соврешались звонки";


            }

            if (comboBox7.SelectedIndex == 8)
            {

                NpgsqlDataAdapter da = new NpgsqlDataAdapter($"""SELECT * FROM "второй запрос по варианту" """, con);

                DataSet dt = new DataSet();
                da.Fill(dt);
                dataGridView4.DataSource = dt.Tables[0];
                textBox6.Text = "Определить среднее время разговора по каждой АТС и по городу в целом";


            }

            if (comboBox7.SelectedIndex == 9)
            {
                label13.Visible = true;
                label15.Visible = true;
                label16.Visible = true;
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                button21.Visible = true;
                panel3.Visible = true;
                textBox6.Text = "Вывод звонков, АТС которых открылись в промежутке IN";


            }

            if (comboBox7.SelectedIndex == 10)
            {

                NpgsqlDataAdapter da = new NpgsqlDataAdapter($"""SELECT * FROM "запрос с подзапросом_с_not_in" """, con);

                DataSet dt = new DataSet();
                da.Fill(dt);
                dataGridView4.DataSource = dt.Tables[0];
                textBox6.Text = "Вывод звонков абонентов, у которых нет льготы NOT IN";


            }

            if (comboBox7.SelectedIndex == 11)
            {

                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM запрос_с_подзапросом_case", con);

                DataSet dt = new DataSet();
                da.Fill(dt);
                dataGridView4.DataSource = dt.Tables[0];
                textBox6.Text = "Вывод атс, чьё количество абонентов выше среднего (популярное/ не популярное)";


            }
            if (comboBox7.SelectedIndex == 13)
            {

                NpgsqlDataAdapter da = new NpgsqlDataAdapter($"""SELECT * FROM "первый запрос по варианту по одной" """, con);

                DataSet dt = new DataSet();
                da.Fill(dt);
                dataGridView4.DataSource = dt.Tables[0];
                textBox6.Text = "Определить, кто из социальных категорий чаще пользуется услугами АТС по одной категории для каждой АТС";


            }

            if (comboBox7.SelectedIndex == 14)
            {

                NpgsqlDataAdapter da = new NpgsqlDataAdapter($"""SELECT * FROM "первый запрос по варианту по город" """, con);

                DataSet dt = new DataSet();
                da.Fill(dt);
                dataGridView4.DataSource = dt.Tables[0];
                textBox6.Text = "Определить, кто из социальных категорий чаще пользуется услугами АТС по городу в целом";


            }

            if (comboBox7.SelectedIndex == 16)
            {

                NpgsqlDataAdapter da = new NpgsqlDataAdapter($"""SELECT * FROM "второй запрос по варианту" """, con);

                DataSet dt = new DataSet();
                da.Fill(dt);
                dataGridView4.DataSource = dt.Tables[0];
                textBox6.Text = "Определить среднее время разговора по каждой АТС и по городу в целом";


            }
            if (comboBox7.SelectedIndex == 18)
            {
                label19.Visible = true;
                comboBox9.Visible = true;
                panel3.Visible = true;
                label19.Visible = true;
                button21.Visible = true;
                label18.Visible = true;
                numericUpDown2.Visible = true;
                textBox6.Text = "Определить общее количество переговоров и стоимость этих переговоров в указанный месяц по городским звонкам";

            }
            if (comboBox7.SelectedIndex == 19)
            {

                label19.Visible = true;
                comboBox9.Visible = true;
                panel3.Visible = true;
                label19.Visible = true;
                button21.Visible = true;
                label18.Visible = true;
                numericUpDown2.Visible = true;
                textBox6.Text = "Определить общее количество переговоров и стоимость этих переговоров в указанный месяц по международным звонкам";

            }



        }

        private void button20_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = null;
            textBox6.Clear();
            comboBox7.Text = "";
            label13.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            button21.Visible = false;
            panel3.Visible = false;
            comboBox8.Visible = false;
            numericUpDown1.Visible = false;
            numericUpDown2.Visible = false;
            label19.Visible = false; ;
            comboBox9.Visible = false;
            label18.Visible = false;
        }

        private void plotView1_Click(object sender, EventArgs e)
        {


        }

        private void button21_Click(object sender, EventArgs e)
        {
            string con = "Host=localhost;Username=postgres;Password=5228;Database=postgres";

            NpgsqlConnection nc = new NpgsqlConnection(con);
            nc.Open();
            if (comboBox7.SelectedIndex == 6)
            {
                label13.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                label17.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                button21.Visible = false;
                panel3.Visible = false;
                comboBox8.Visible = false;
                numericUpDown1.Visible = false;
                numericUpDown2.Visible = false;
                label19.Visible = false; ;
                comboBox9.Visible = false;
                label18.Visible = false;


                bool barg = false;
                if (comboBox8.Text == "ГОС")
                {

                    barg = true;

                }
                NpgsqlDataAdapter da = new NpgsqlDataAdapter($"""SELECT * FROM  "итоговый запрос на данные/группы" ({string.Format("'{0}'::date", dateTimePicker1.Value.ToString("yyyy-MM-dd"))}, {string.Format("'{0}'::date", dateTimePicker2.Value.ToString("yyyy-MM-dd"))}, {barg})  """, nc);
                DataSet dt = new DataSet();
                da.Fill(dt);                                //С АРГУМЕНТАМИ
                dataGridView4.DataSource = dt.Tables[0];
                textBox6.Text = "Вывод кол-ва звонков абонентов, АТС которых гос/не гос за указанный период";


            }

            if (comboBox7.SelectedIndex == 9)
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter($"""SELECT * FROM  "запрос с подзапросом_с_in" ({numericUpDown1.Value}, {numericUpDown2.Value})  """, nc);
                DataSet dt = new DataSet();
                da.Fill(dt);                                //С АРГУМЕНТАМИ
                dataGridView4.DataSource = dt.Tables[0];
                textBox6.Text = "Вывод звонков, АТС которых открылись в промежутке IN";


            }

            if (comboBox7.SelectedIndex == 18)
            {
                string monthAndYear = comboBox9.Text + "," + numericUpDown2.Value.ToString();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter($"""SELECT * FROM "третий запрос по варианту по город"('{monthAndYear}') """, con);

                DataSet dt = new DataSet();
                da.Fill(dt);                                //С АРГУМЕНТАМИ
                dataGridView4.DataSource = dt.Tables[0];
                textBox6.Text = "Определить общее количество переговоров и стоимость этих переговоров в указанный месяц по городским звонкам";


            }
            if (comboBox7.SelectedIndex == 19)
            {
                string monthAndYear = comboBox9.Text + "," + numericUpDown2.Value.ToString();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter($"""SELECT * FROM "третий запрос по варианту по межд"('{monthAndYear}') """, con);

                DataSet dt = new DataSet();
                da.Fill(dt);                                //С АРГУМЕНТАМИ
                dataGridView4.DataSource = dt.Tables[0];
                textBox6.Text = "Определить общее количество переговоров и стоимость этих переговоров в указанный месяц по международным звонкам";


            }
        }
    }
}
