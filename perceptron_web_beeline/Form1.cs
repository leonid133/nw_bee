using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Globalization;
using System.Threading;


namespace perceptron_web_beeline
{

    public partial class Form1 : Form
    {
        Web_perceptron g_Neyron;
        public int[,] g_input = new int[63, 349];

        public string m_w_file;
        public int m_max_x_62 = 62;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            NW1 = new Web_perceptron(3, 5, input); // Создаем экземпляр нашего нейрона

            openFileDialog1.Title = "Укажите файл весов";
            openFileDialog1.ShowDialog();
            m_w_file = openFileDialog1.FileName;
            StreamReader sr = File.OpenText(m_w_file);  // Загружаем файл весов
            string line;
            string[] s1;
            int k = 0;
            while ((line = sr.ReadLine()) != null)
            {

                s1 = line.Split(' ');
                for (int i = 0; i < s1.Length; i++)
                {
                    listBox1.Items.Add("");
                    if (k < 5)
                    {
                        NW1.m_weight[i, k] = Convert.ToInt32(s1[i]); // Назначаем каждой связи её записанный ранее вес
                        listBox1.Items[k] += Convert.ToString(NW1.m_weight[i, k]); // Выводим веса, для наглядности
                    }

                }
                k++;

            }
            sr.Close();
             * */
        }
        private void g_PunishNeyron()
        {
            button_train.Enabled = false;

            if (g_Neyron.Rez() == false)
                g_Neyron.incW(g_input);
            else g_Neyron.decW(g_input);

            //Запись
            string s = "";

            System.IO.File.Delete(m_w_file);
            FileStream FS = new FileStream(m_w_file, FileMode.OpenOrCreate);
            StreamWriter SW = new StreamWriter(FS);

            Dictonary_train y_dictonary = new Dictonary_train("y");

            Dictonary_train[] x_dictonary = new Dictonary_train[m_max_x_62];
            int max_y = 0;
            for (int it_x = 0; it_x < m_max_x_62; ++it_x)
            {
                string f_name = "x" + it_x.ToString();
                x_dictonary[it_x] = new Dictonary_train(f_name);
                if (x_dictonary[it_x].Count() > max_y)
                    max_y = x_dictonary[it_x].Count();
            }

            string[] s1 = new string[max_y];
            for (int y = 0; y < max_y; y++)
            {

                for (var x = 0; x < m_max_x_62; x++)
                {
                    s += Convert.ToString(g_Neyron.m_weight[x, y]);
                    if (x != m_max_x_62) s += " ";
                }

                s1[y] = s;

                SW.WriteLine(s);
                s = "";

            }
            SW.Close();
        }
        private void g_NW_Activate()
        {
            button_train.Enabled = true;

            Dictonary_train y_dictonary = new Dictonary_train("y");

            Dictonary_train[] x_dictonary = new Dictonary_train[m_max_x_62];
            int max_y = 0;
            for (int it_x = 0; it_x < m_max_x_62; ++it_x)
            {
                string f_name = "x" + it_x.ToString();
                x_dictonary[it_x] = new Dictonary_train(f_name);
                if (x_dictonary[it_x].Count() > max_y)
                    max_y = x_dictonary[it_x].Count();
            }
            g_Neyron = new Web_perceptron(m_max_x_62, max_y, g_input); // Создаем экземпляр нашего нейрона

            openFileDialog1.Title = "Укажите файл весов";
            openFileDialog1.ShowDialog();
            m_w_file = openFileDialog1.FileName;
            StreamReader sr = File.OpenText(m_w_file);  // Загружаем файл весов
            string line;
            string[] s1;
            int k = 0;
            try
            {
                while ((line = sr.ReadLine()) != null)
                {

                    s1 = line.Split(' ');
                    for (int i = 0; i < s1.Length; i++)
                    {
                        listBox1.Items.Add("");
                        if (k < max_y)
                        {
                            g_Neyron.m_weight[i, k] = Convert.ToInt32(s1[i]); // Назначаем каждой связи её записанный ранее вес
                            listBox1.Items[k] += Convert.ToString(g_Neyron.m_weight[i, k]); // Выводим веса, для наглядности
                        }

                    }
                    k++;

                }
            }
            catch { }
            sr.Close();
        }
        private void g_Train()
        {

            button_train.Enabled = true;
            listBox1.Items.Clear();
            openFileDialog1.Title = "Укажите тестируемый файл";
            openFileDialog1.ShowDialog();
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            Bitmap im = pictureBox1.Image as Bitmap;

            Dictonary_train y_dictonary = new Dictonary_train("y");

            Dictonary_train[] x_dictonary = new Dictonary_train[m_max_x_62];
            int max_y = 0;
            for (int it_x = 0; it_x < m_max_x_62; ++it_x)
            {
                string f_name = "x" + it_x.ToString();
                x_dictonary[it_x] = new Dictonary_train(f_name);
                if (x_dictonary[it_x].Count() > max_y)
                    max_y = x_dictonary[it_x].Count();
            }

            //for (var i = 0; i < max_y; i++) listBox1.Items.Add(" ");

            for (var x = 0; x < m_max_x_62; x++)
            {
                for (var y = 0; y < max_y; y++)
                {
                    // listBox1.Items.Add(Convert.ToString(im.GetPixel(x, y).R));
                    int n = (im.GetPixel(x, y).R);
                    if (n >= 250) n = 0;
                    else n = 1;
                    //listBox1.Items[y] = listBox1.Items[y] + "  " + Convert.ToString(n);
                    g_input[x, y] = n;
                    //if (n == 0) input[x, y] = 1;
                }

            }

            g_recognize();

        }

        private void button_NeyroActivate_Click(object sender, EventArgs e)
        {
            g_NW_Activate();
        }

        public bool g_recognize()
        {
            g_Neyron.mul_w();
            g_Neyron.Sum();
            if (g_Neyron.Rez()) listBox1.Items.Add(" - True, Sum = " + Convert.ToString(g_Neyron.m_sum));
            else listBox1.Items.Add(" - False, Sum = " + Convert.ToString(g_Neyron.m_sum));
            return g_Neyron.Rez();
        }
      
        private void button_open_Click(object sender, EventArgs e)
        {
            g_Train();
            /*
            listBox1.Items.Clear();
            button_train.Enabled = true;
            openFileDialog1.Title = "Укажите тестируемый файл";
            openFileDialog1.ShowDialog();
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            Bitmap im = pictureBox1.Image as Bitmap;
            for (var i = 0; i <= 5; i++) listBox1.Items.Add(" ");

            for (var x = 0; x <= 2; x++)
            {
                for (var y = 0; y <= 4; y++)
                {
                    // listBox1.Items.Add(Convert.ToString(im.GetPixel(x, y).R));
                    int n = (im.GetPixel(x, y).R);
                    if (n >= 250) n = 0;
                    else n = 1;
                    listBox1.Items[y] = listBox1.Items[y] + "  " + Convert.ToString(n);
                    input[x, y] = n;
                    //if (n == 0) input[x, y] = 1;
                }

            }

            recognize();
             * */
        }

        private void button_train_Click(object sender, EventArgs e)
        {
            g_PunishNeyron();
            /*
            button_train.Enabled = false;

            if (NW1.Rez() == false)
                NW1.incW(input);
            else NW1.decW(input);

            //Запись
            string s = "";
            string[] s1 = new string[5];
            System.IO.File.Delete(m_w_file);
            FileStream FS = new FileStream(m_w_file, FileMode.OpenOrCreate);
            StreamWriter SW = new StreamWriter(FS);

            for (int y = 0; y <= 4; y++)
            {

                s = Convert.ToString(NW1.m_weight[0, y]) + " " + Convert.ToString(NW1.m_weight[1, y]) + " " + Convert.ToString(NW1.m_weight[2, y]);


                s1[y] = s;

                SW.WriteLine(s);

            }
            SW.Close();
             * */
        }
        private long ParseHexString(string hex)
        {
            long result = 0;
            try
            {
                result = Convert.ToInt64(hex, 16);
               // Console.WriteLine("Converted hex'{0}' to int64 {1}.", hex, result);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert hex'{0}'.", hex);
            }
            catch (OverflowException)
            {
                Console.WriteLine("'{0}' is out of range.", hex);
            }
            return result;
        }
        private Int32 ParseIntString(string int_str)
        {
            int result = -1000000;
            try
            {
                result = Convert.ToInt32(int_str, 16);
                //Console.WriteLine("Converted int'{0}' to int32 {1}.", int_str, result);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert int32'{0}'.", int_str);
            }
            catch (OverflowException)
            {
                Console.WriteLine("'{0}' is out of range.", int_str);
            }
            return result;
        }
        private double ParseDoubleString(String double_str)
        {
            double result = -1000000.0;
            try
            {
                NumberStyles ns = NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite;
                result = Double.Parse(double_str, ns, CultureInfo.InvariantCulture);
             //   if( Double.TryParse(double_str, out result) )
                   // Console.WriteLine("Converted '{0}' to double {1}.", double_str, result);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert '{0}' to a Double.", double_str);
            }
            catch (OverflowException)
            {
                Console.WriteLine("'{0}' is outside the range of a Double.", double_str);
            }
            return result;
        }

        private string PixelizeFloatingData(string data_string)
        {
            string resultpixel = "NullPixell";
            double double_item = ParseDoubleString(data_string);
            if (double_item < (-1000000.0 + 0.1))
                return resultpixel;
            
            double part0 = (Math.Pow(10, (-Math.Truncate(Math.Log(Math.Abs(double_item))))) * 10);
            double part1 = Math.Truncate(double_item * part0);
            int pow_n = 2;
            if (Math.Abs(part1) <= 1)
            {
                while (Math.Abs(part1) <= 1 && pow_n < 25)
                {
                    part0 = (Math.Pow(10, (-Math.Truncate(Math.Log(Math.Abs(double_item))))) * Math.Pow(10, pow_n++));
                    part1 = Math.Truncate(double_item * part0);
                }
            }
            double_item = part1 / part0; //ЦЕЛОЕ(BG2*10^(-ЦЕЛОЕ(LOG(ABS(BG2))))*10)/(10^(-ЦЕЛОЕ(LOG(ABS(BG2))))*10)
            resultpixel = double_item.ToString("E1");
            return resultpixel ;
        }
        private void button_CreateDict_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            button_train.Enabled = true;
            openFileDialog1.Title = "Укажите тестируемый файл";
            openFileDialog1.ShowDialog();

            try
            {
                using (StreamReader sr = File.OpenText(openFileDialog1.FileName))
                {
                    string readline_buffer = "";
                    int count_lines = 0;
                    
                    Hashtable[] x_value_has = new Hashtable[m_max_x_62];
                    List<int>[] x_value_list = new List<int>[m_max_x_62];
                    for (int i = 0; i < m_max_x_62; ++i)
                    {
                        x_value_has[i] = new Hashtable();
                        x_value_list[i] = new List<int>();
                    }
                    List<int> y_value_list = new List<int>();
                    int[] x_has = new int[m_max_x_62];

                    while ((readline_buffer = sr.ReadLine()) != null)
                    {
                        
                        //listBox1.Items.Add(" ");
                        //var sentences = new List<String>();
                        char[] charSeparators = new char[] { ',' };
                        string[] result = readline_buffer.Split(charSeparators, StringSplitOptions.None);
                        
                        for (int it_item = 0; it_item < result.Count(); ++it_item)
                        {
                           // Console.WriteLine(result[it_item]);
                            //listBox1.Items[count_lines] = listBox1.Items[count_lines] + "  " + result[it_item];
                            try
                            {
                                if (it_item != 62)
                                {
                                    if (ItemIsDouble(it_item))
                                    {
                                        String item_value =  PixelizeFloatingData(result[it_item]);
                                        if (!x_value_has[it_item].Contains(item_value))
                                        {
                                            ++x_has[it_item];
                                            x_value_has[it_item].Add(item_value, x_has[it_item]);
                                        }
                                        int int_val = ParseIntString(x_value_has[it_item][item_value].ToString());
                                        x_value_list[it_item].Add(int_val);
                                    }
                                    else if (ItemIsHex(it_item))
                                    {
                                        String item_value = PixelizeFloatingData(ParseHexString(result[it_item]).ToString());
                                        if (!x_value_has[it_item].Contains(item_value))
                                        {
                                            ++x_has[it_item];
                                            x_value_has[it_item].Add(item_value, x_has[it_item]);
                                        }
                                        int int_val = ParseIntString(x_value_has[it_item][item_value].ToString());
                                        x_value_list[it_item].Add(int_val);
                                    }
                                    else
                                    {
                                        //long long_value_x0 = ParseHexString(result[it_item]);
                                        String item_value = result[it_item];
                                        if (!x_value_has[it_item].Contains(item_value))
                                        {
                                            ++x_has[it_item];
                                            x_value_has[it_item].Add(item_value, x_has[it_item]);
                                        }
                                        int int_val = ParseIntString(x_value_has[it_item][item_value].ToString());
                                        x_value_list[it_item].Add(int_val);
                                    }
                                }
                                
                                if (it_item == m_max_x_62)
                                {
                                    int int_value_y = ParseIntString(result[it_item]);
                                    y_value_list.Add(int_value_y);
                                }
                            }
                            catch { }
                        }
                        ++count_lines;
                       // if (count_lines > 500) //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                         //   break;
                    }
                    listBox1.Items.Add("Добавлено строчек: " + count_lines.ToString());

                    Dictonary_train y_dictonary = new Dictonary_train("y");
                    y_dictonary.SetDict(ref y_value_list);
                    y_dictonary.Flush();
                    for (int it_x = 0; it_x < m_max_x_62; ++it_x )
                    {
                        string f_name = "x" + it_x.ToString();
                        Dictonary_train x_dictonary = new Dictonary_train(f_name);
                        x_dictonary.SetDict(ref x_value_has[it_x]);
                        x_dictonary.Flush();
                    }
                    
                    int count_y = 0;
                    /*
                    foreach (DictionaryEntry de in y_value_list)
                    {
                        listBox1.Items.Add(" ");
                        Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
                        x0_dictonary.SetDict(de.Key.ToString(), de.Value.ToString());
                        x0_dictonary.Flush();
                        listBox1.Items[count_y++] = de.Key + "  " + y_dictonary.m_dictonary_map[de.Key.ToString()].ToString();
                    }  */
                    foreach (var list_de in y_value_list)
                    {
                        listBox1.Items.Add(" ");
                        listBox1.Items[count_y++] = list_de.ToString() + "  " + y_dictonary.m_dictonary_map[list_de.ToString()].ToString();
                    }
                    for (int it_x = 0; it_x < m_max_x_62; ++it_x)
                    {
                        string f_name = "x" + it_x.ToString();
                        Dictonary_train x_dictonary = new Dictonary_train(f_name);
                        foreach (var key in x_value_has[it_x].Keys)
                        {
                            listBox1.Items.Add(" ");
                            listBox1.Items[count_y++] = f_name + "  " + x_dictonary.m_dictonary_map[key.ToString()];
                        }
                    }
                    

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        private void BItmapCreater(string input_string, string output_file_prefix, int max_y, Dictonary_train y_dictonary, List<Dictonary_train> x_dictonary)
        {
            string output_filename = output_file_prefix;
            char[] charSeparators = new char[] { ',' };
            string[] result = input_string.Split(charSeparators, StringSplitOptions.None);

            try
            {
                bool bitmap_created = false;

                var im = new Bitmap(m_max_x_62, max_y);
                for (var x = 0; x < m_max_x_62; x++)
                {
                    for (var y = 0; y < max_y; y++)
                    {
                        /*
                        int n = (im.GetPixel(x, y).R);
                        if (n >= 250) n = 0;
                        else n = 1;*/
                        im.SetPixel(x, y, Color.White);
                    }
                }
                bitmap_created = true;


                for (int it_item = 0; it_item < result.Count(); ++it_item)
                {
                    if (it_item != 62)
                    {
                        if (ItemIsDouble(it_item))
                        {
                            String item_value = PixelizeFloatingData(result[it_item]);
                            int y_dot = x_dictonary[it_item].m_dictonary_map[item_value];
                            if (bitmap_created) im.SetPixel(it_item, y_dot, Color.Black);
                        }
                        else if (ItemIsHex(it_item))
                        {
                            String item_value = PixelizeFloatingData(ParseHexString(result[it_item]).ToString());
                            int y_dot = x_dictonary[it_item].m_dictonary_map[item_value];
                            if (bitmap_created) im.SetPixel(it_item, y_dot, Color.Black);
                        }
                        else
                        {
                            //long long_value_x0 = ParseHexString(result[it_item]);
                            String item_value = result[it_item];
                            int y_dot = x_dictonary[it_item].m_dictonary_map[item_value];
                            if (bitmap_created) im.SetPixel(it_item, y_dot, Color.Black);
                        }
                    }

                    if (it_item == m_max_x_62)
                    {
                        int int_value_y = ParseIntString(result[it_item]);
                        output_filename += "x_" + int_value_y.ToString() + "_.bmp";
                    }
                }
                if (bitmap_created) im.Save(output_filename);
                im.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {

            }
        }
        private void button_BitmapCreater_Click(object sender, EventArgs e)
        {

            openFileDialog1.Title = "Укажите файл обучающих данных";
            openFileDialog1.ShowDialog();

            using (StreamReader sr = File.OpenText(openFileDialog1.FileName))
            {

                /*******/
                Dictonary_train y_dictonary = new Dictonary_train("y");
                
                List<Dictonary_train> x_dictonary = new List<Dictonary_train>();
                int max_y = 0;
                for (int it_x = 0; it_x < m_max_x_62; ++it_x)
                {
                    string f_name = "x" + it_x.ToString();
                    x_dictonary.Add(new Dictonary_train(f_name));
                    if (x_dictonary[it_x].Count() > max_y)
                        max_y = x_dictonary[it_x].Count();
                }
                /*****/
                int line_counter = 0;
                string readline_buffer = "";
                while ((readline_buffer = sr.ReadLine()) != null)
                {
                   // if (line_counter > 1554)
                        BItmapCreater(readline_buffer, line_counter.ToString(), max_y, y_dictonary, x_dictonary);
                    readline_buffer = "";
                    ++line_counter;
                }
            }
        }
        

        
        /*
        private void LoadCreateNeyro( ref Web_perceptron neyron)
        {
           string line;
            string[] s1;
            int k = 0;
            StreamReader sr_weight = File.OpenText(m_w_file);  // Загружаем файл весов
            try
            {
                while ((line = sr_weight.ReadLine()) != null)
                {

                    s1 = line.Split(' ');
                    for (int i = 0; i < s1.Length; i++)
                    {
                        listBox1.Items.Add("");
                        if (k < )
                        {
                            neyron.m_weight[i, k] = Convert.ToInt32(s1[i]); // Назначаем каждой связи её записанный ранее вес
                            //listBox1.Items[k] += Convert.ToString(neyron.m_weight[i, k]); // Выводим веса, для наглядности
                        }

                    }
                    k++;

                }
            }
            catch { }
            finally
            {
                sr_weight.Close();
            }
        }*/
        /*
        private void TrainThis(bool train_to_this )
        {

            listBox1.Items.Clear();
            
            
            Bitmap im = pictureBox1.Image as Bitmap;

            Dictonary_train y_dictonary = new Dictonary_train("y");
            
            Dictonary_train[] x_dictonary = new Dictonary_train[x_count];
            int max_y = 0;
            for (int it_x = 0; it_x < x_count; ++it_x)
            {
                string f_name = "x" + it_x.ToString();
                x_dictonary[it_x] = new Dictonary_train(f_name);
                if (x_dictonary[it_x].Count() > max_y)
                    max_y = x_dictonary[it_x].Count();
            }

            for (var x = 0; x < x_count; x++)
            {
                for (var y = 0; y < max_y; y++)
                {
                    int n = (im.GetPixel(x, y).R);
                    if (n >= 250) n = 0;
                    else n = 1;
                    //m_input[x, y] = n;
                }

            }

            //recognize();

        }*/
        private void AutoTrain(int it_w, string name_bmp, int max_y, Dictonary_train y_dictonary, List<Dictonary_train> x_dictonary)
        {
            
            int[,] input = new int[m_max_x_62, max_y];
            Web_perceptron neyron = new Web_perceptron(m_max_x_62, max_y, input);

            //*********************
            string line_read_weight_buffer;
            string[] str_weight_read_buffer = new string[max_y];
            int it_weight_y = 0;
            StreamReader sr_weight = File.OpenText(m_w_file);  // Загружаем файл весов
            try
            {
                while ((line_read_weight_buffer = sr_weight.ReadLine()) != null)
                {

                    str_weight_read_buffer = line_read_weight_buffer.Split(' ');
                    for (int it_weight_x = 0; it_weight_x < m_max_x_62; it_weight_x++)
                    {
                        //listBox1.Items.Add("");
                        if (it_weight_y < max_y)
                        {
                            neyron.m_weight[it_weight_x, it_weight_y] = Convert.ToInt32(str_weight_read_buffer[it_weight_x]); // Назначаем каждой связи её записанный ранее вес
                            //listBox1.Items[k] += Convert.ToString(neyron.m_weight[i, k]); // Выводим веса, для наглядности
                        }

                    }
                    it_weight_y++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sr_weight.Close();
            }
            //*********************
            
            char[] bmp_filename_charSeparators = new char[] { '_' };
            string[] result_split_bmp = name_bmp.Split(bmp_filename_charSeparators, StringSplitOptions.None);
            int bmp_file_suffix = 9;
            for (int it_bmp_split_name = 0; it_bmp_split_name < result_split_bmp.Count(); ++it_bmp_split_name)
            {
               
                try
                {
                    if (it_bmp_split_name == 1)
                        bmp_file_suffix = Int32.Parse(result_split_bmp[it_bmp_split_name]);
                }
                catch { }
            }
            bool train_to_this = false;
            if (it_w == bmp_file_suffix)
                train_to_this = true;

            
            //***********
            Bitmap im = pictureBox1.Image as Bitmap;

            for (var x = 0; x < m_max_x_62; x++)
            {
                for (var y = 0; y < max_y; y++)
                {
                    int n = (im.GetPixel(x, y).R);
                    if (n >= 250) n = 0;
                    else n = 1;
                    input[x, y] = n;
                }

            }
            neyron.mul_w();
            neyron.Sum();
            if ((neyron.Rez() && !train_to_this) || (!neyron.Rez() && train_to_this))
            {
                if (neyron.Rez() == false)
                    neyron.incW(input);
                else neyron.decW(input);

                //Запись

                string str_write_weight_buffer = "";

                //System.IO.File.Delete(m_w_file);
                FileStream fs_weight_writer = new FileStream(m_w_file, FileMode.OpenOrCreate);
                StreamWriter sw_weight_writer = new StreamWriter(fs_weight_writer);

                string[] s1 = new string[max_y];
                for (int y = 0; y < max_y; y++)
                {

                    for (var x = 0; x < m_max_x_62; x++)
                    {
                        str_write_weight_buffer += Convert.ToString(neyron.m_weight[x, y]);
                        if (x != m_max_x_62) str_write_weight_buffer += " ";
                    }

                    s1[y] = str_write_weight_buffer;

                    sw_weight_writer.WriteLine(str_write_weight_buffer);
                    str_write_weight_buffer = "";

                }

                sw_weight_writer.Close();
                fs_weight_writer.Close();
            }      
            //***********
        }
       
        private void button_AutoTrain_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp|All files (*.*)|*.*" ;
            openFileDialog1.FilterIndex = 2 ;
            openFileDialog1.RestoreDirectory = true ;
            openFileDialog1.Multiselect = true;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Dictonary_train y_dictonary = new Dictonary_train("y");
                int x_count = 62;
                List<Dictonary_train> x_dictonary = new List<Dictonary_train>();
                int max_y = 0;
                for (int it_x = 0; it_x < x_count; ++it_x)
                {
                    string f_name = "x" + it_x.ToString();
                    x_dictonary.Add(new Dictonary_train(f_name));
                    if (x_dictonary[it_x].Count() > max_y)
                        max_y = x_dictonary[it_x].Count();
                }
                try
                {
                    for (int it_w = 0; it_w < 8; ++it_w)
                    {
                        int it_file = 0;
                        foreach (string file in openFileDialog1.FileNames)
                        {
                            //listBox1.Items.Add(file);
                            m_w_file = "w" + it_w.ToString();
                            pictureBox1.Image = Image.FromFile(file);
                            AutoTrain(it_w, openFileDialog1.SafeFileNames[it_file++].ToString(), max_y, y_dictonary, x_dictonary);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
                finally
                {
                    openFileDialog1.Multiselect = false;
                }
            }

            MessageBox.Show("Auto train success!");
        }

        private bool ItemIsDouble(int it_item)
        {
            if (it_item == 8 || it_item == 13 || it_item == 23 || it_item == 24 || it_item == 25 || it_item == 26 || it_item == 27 || it_item == 28 || it_item == 29 || it_item == 30 || it_item == 31 || it_item == 32 || it_item == 33 || it_item == 34 || it_item == 35 || it_item == 36 || it_item == 37 || it_item == 38 || it_item == 39 || it_item == 40 || it_item == 41 || it_item == 42 || it_item == 43 || it_item == 44 || it_item == 45 || it_item == 46 || it_item == 47 || it_item == 48 || it_item == 49 || it_item == 50 || it_item == 51 || it_item == 52 || it_item == 53 || it_item == 54 || it_item == 55 || it_item == 56 || it_item == 57 || it_item == 58 || it_item == 59 || it_item == 60 || it_item == 61)
                return true;
            else return false;
        }
        private bool ItemIsHex(int it_item)
        {
            if (!ItemIsDouble(it_item) &&( it_item == 0 || it_item == 1 || it_item == 2 || it_item == 10 || it_item == 11 || it_item == 12 || it_item == 14 || it_item == 15 || it_item == 16 || it_item == 17 || it_item == 18 || it_item == 19 || it_item == 20 || it_item == 21 || it_item == 22 ))
                return true;
            else
                return false;
        }

    }
}

