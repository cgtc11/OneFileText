using System;
using System.IO;
using System.Windows.Forms;

namespace FileConcatenator
{
    public partial class Form1 : Form
    {
        private SaveFileDialog saveFileDialog;
        private bool isFileSaved = false; // ファイルが保存されたかどうかを示すフラグ

        public Form1()
        {
            InitializeComponent();
            fileListBox.AllowDrop = true;
            fileListBox.DragEnter += new DragEventHandler(FileListBox_DragEnter);
            fileListBox.DragDrop += new DragEventHandler(FileListBox_DragDrop);
            fileListBox.MouseDown += new MouseEventHandler(FileListBox_MouseDown);
            fileListBox.MouseMove += new MouseEventHandler(FileListBox_MouseMove);
            executeButton.Click += new EventHandler(ExecuteButton_Click);

            saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "保存先を選択してください"
            };
        }

        private void FileListBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FileListBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                fileListBox.Items.Add(file);
            }
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            if (fileListBox.Items.Count == 0)
            {
                MessageBox.Show("ファイルを追加してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!isFileSaved && saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string savePath = saveFileDialog.FileName;
                ConcatenateFiles(savePath);
                isFileSaved = true; // ファイルが保存されたことを示す
            }
        }

        private void ConcatenateFiles(string savePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(savePath))
                {
                    foreach (string file in fileListBox.Items)
                    {
                        writer.WriteLine(Path.GetFileName(file));
                        writer.WriteLine(new string('-', 50));
                        writer.WriteLine(File.ReadAllText(file));
                        writer.WriteLine(new string('-', 50));
                    }
                }
                MessageBox.Show("ファイルを結合して保存しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int dragIndex = -1;

        private void FileListBox_MouseDown(object sender, MouseEventArgs e)
        {
            dragIndex = fileListBox.IndexFromPoint(e.X, e.Y);
        }

        private void FileListBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && dragIndex != -1)
            {
                int newIndex = fileListBox.IndexFromPoint(e.X, e.Y);
                if (newIndex != -1 && newIndex != dragIndex)
                {
                    object item = fileListBox.Items[dragIndex];
                    fileListBox.Items.RemoveAt(dragIndex);
                    fileListBox.Items.Insert(newIndex, item);
                    dragIndex = newIndex;
                }
            }
        }
    }
}
