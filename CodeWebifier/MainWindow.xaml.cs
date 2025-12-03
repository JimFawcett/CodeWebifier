using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
#pragma warning disable CS0105 // The using directive for 'System.Text' appeared previously in this namespace
using System.Text;
#pragma warning restore CS0105 // The using directive for 'System.Text' appeared previously in this namespace
using Microsoft.Win32;

namespace CodeWebifier
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private string fileText = "";
    private string startDir = Properties.Settings.Default.StartPath;

    public MainWindow()
    {
      InitializeComponent();
      WebifyButton.IsEnabled = false;
      FileNameTextBox.Text = Properties.Settings.Default.StartPath.ToString();
      FileNameTextBox.Width = this.Width - 60;
    }

    //~MainWindow()
    //{
    //  Properties.Settings.Default.StartPath = startDir;
    //}

    private void BrowseButton_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog dlg = new OpenFileDialog();
      dlg.InitialDirectory = startDir;
      if (dlg.ShowDialog() == true)
      {
        fileText = File.ReadAllText(dlg.FileName);
        FileTextBlock.Text = fileText;
        FileNameTextBox.Text = dlg.FileName;
        startDir = System.IO.Path.GetDirectoryName(dlg.FileName);
        Properties.Settings.Default.StartPath = startDir;
        Properties.Settings.Default.Save();
        WebifyButton.IsEnabled = true;
        Console.Clear();
      }
    }

    // Older-C# friendly: no index-from-end operator
    private static int GetTotalLines(string text)
    {
      if (string.IsNullOrEmpty(text)) return 0;

      int nl = 0;
      for (int i = 0; i < text.Length; ++i)
        if (text[i] == '\n') nl++;

      bool endsWithNewline = text.Length > 0 && text[text.Length - 1] == '\n';
      return nl + (endsWithNewline ? 0 : 1);
    }

    private void WebifyButton_Click(object sender, RoutedEventArgs e)
    {
      WebifyButton.IsEnabled = false;
      StringBuilder webified = new StringBuilder();
      int size = fileText.Length;

      bool showLineNumbers = (LineNumbersCheckBox != null && LineNumbersCheckBox.IsChecked == true);
      int totalLines = GetTotalLines(fileText);
      int lineFieldWidth = Math.Max(1, totalLines.ToString().Length);

      Console.Write("\n<div class='code'>");
      Console.Write("\n<pre>\n");

      int lineIndex = 1;

      if (showLineNumbers && totalLines > 0)
      {
        Console.Write(lineIndex.ToString().PadLeft(lineFieldWidth));
        Console.Write(" ");
      }

      for (int i = 0; i < size; ++i)
      {
        char ch = fileText[i];
        switch (ch)
        {
          case '<':
            Console.Write("&lt;");
            break;
          case '>':
            Console.Write("&gt;");
            break;
          case '\\':
            Console.Write("&#92;");
            break;
          case '"':
            Console.Write("&quot;");
            break;
          case '\r':
            break;
          case '\n':
            Console.Write("\n");
            if (showLineNumbers && ++lineIndex <= totalLines)
            {
              Console.Write(lineIndex.ToString().PadLeft(lineFieldWidth));
              Console.Write(" ");
            }
            break;
          default:
            Console.Write(ch);
            break;
        }
      }
      Console.Write("\n</pre>");
      Console.Write("\n</div>");
    }

    private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
    {
      FileNameTextBox.Width = this.Width - 60;
    }
  }
}
