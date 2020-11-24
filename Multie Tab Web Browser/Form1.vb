Imports System.IO
Imports System.Net
Public Class Form1
    Dim i As Integer = 1
    Private Sub WebBrowser1_StatusTextchanged()
        Try
            StatusText.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).StatusText
        Catch
        End Try
    End Sub

    Private Sub NewTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewTabToolStripMenuItem.Click
        Try
            Dim t As New TabPage
            Dim tab As New WebBrowser
            i = i + 1
            tab.Dock = DockStyle.Fill
            t.Controls.Add(tab)
            TabControl1.TabPages.Add(t)
            TabControl1.SelectTab(t)
            tab.Navigate("www.google.com")
            TabControl1.Controls.Item(i - 1).Text = "Google"
            AddHandler tab.StatusTextChanged, AddressOf WebBrowser1_StatusTextchanged
            ComboBox1.Text = "www.google.com"
        Catch
        End Try
    End Sub

    Private Sub CloseTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseTabToolStripMenuItem.Click
        Try
            If Not TabControl1.TabPages.Count = 1 Then
                TabControl1.TabPages.RemoveAt(TabControl1.SelectedIndex)
                TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
                i = i - 1
            End If
        Catch
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Try
            CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoBack()
        Catch
        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Try
            CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoForward()
        Catch
        End Try
    End Sub

    Private Sub NewWindowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewWindowToolStripMenuItem.Click
        Try
            Dim f As New Form1
            f.Show()
        Catch
        End Try
    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles ComboBox1.Click
        Timer4.Stop()
        Try
            ComboBox1.Items.Clear()
            Dim sr As New StreamReader(Application.StartupPath & "\Favoris.txt")
            TextBox1.Text = sr.ReadToEnd
            sr.Close()
            For i As Integer = 0 To TextBox1.Lines.Length - 1
                ComboBox1.Items.Add(TextBox1.Lines(i))
            Next
        Catch
        End Try
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate(ComboBox1.Text)
            End If
        Catch
        End Try
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Try
            CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Refresh()
        Catch
        End Try
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Try
            CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate(ComboBox1.Text)
        Catch
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim ww As New WebBrowser
            TabControl1.TabPages.Add("Google")
            ww.Dock = DockStyle.Fill
            TabControl1.SelectedTab.Controls.Add(ww)
            CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate(ComboBox1.Text)
            AddHandler ww.StatusTextChanged, AddressOf WebBrowser1_StatusTextchanged
        Catch
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try

            TabControl1.SelectedTab.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).DocumentTitle
            Do Until CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).ReadyState = WebBrowserReadyState.Complete
                Application.DoEvents()
            Loop
            TabControl1.SelectedTab.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).DocumentTitle
        Catch
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        Try
            CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Refresh()
        Catch
        End Try
    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click
        Try
            CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoForward()
        Catch
        End Try
    End Sub

    Private Sub NextTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NextTabToolStripMenuItem.Click
        Try
            Dim cp As Integer = TabControl1.TabCount - 1
            If cp > TabControl1.SelectedIndex Then
                TabControl1.SelectTab(TabControl1.SelectedIndex + 1)
            End If
        Catch
        End Try
    End Sub

    Private Sub BackTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackTabToolStripMenuItem.Click
        Try
            If 0 < TabControl1.SelectedIndex Then
                TabControl1.SelectTab(TabControl1.SelectedIndex - 1)
            End If
        Catch
        End Try
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Try
            TextBox1.Text = TextBox1.Text + vbNewLine + ComboBox1.Text
            Dim sw As New StreamWriter(Application.StartupPath & "\Favoris.txt")
            sw.Write(TextBox1.Text)
            sw.Close()
            ComboBox1.Items.Clear()
            Dim sr As New StreamReader(Application.StartupPath & "\Favoris.txt")
            TextBox1.Text = sr.ReadToEnd
            sr.Close()
            For i As Integer = 0 To TextBox1.Lines.Length - 1
                ComboBox1.Items.Add(TextBox1.Lines(i))
            Next
        Catch
        End Try
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Try
            Panel3.Visible = False
        Catch
        End Try
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Try
            Panel3.Visible = True
            ListBox1.Items.Clear()
            Dim sr As New StreamReader(Application.StartupPath & "\Historic.txt")
            TextBox2.Text = sr.ReadToEnd
            sr.Close()
            For i As Integer = 0 To TextBox2.Lines.Length - 1
                ListBox1.Items.Add(TextBox2.Lines(i))
            Next
            Timer3.Start()
        Catch
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            Do Until CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).ReadyState = WebBrowserReadyState.Complete
                Application.DoEvents()
            Loop
            If ListBox1.Items(ListBox1.Items.Count - 1) <> CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Document.Domain Then
                ListBox1.Items.Add(CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Document.Domain)
            End If
        Catch
        End Try
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        ComboBox1.Text = ListBox1.SelectedItem
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate(ComboBox1.Text)
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Try
            TextBox3.Clear()
            For i As Integer = 0 To ListBox1.Items.Count - 1
                TextBox3.Text = TextBox3.Text + ListBox1.Items(i) + vbNewLine
            Next
            TextBox3.Text = TextBox3.Text.TrimEnd
            Dim sw As New StreamWriter(Application.StartupPath & "\Historic.txt")
            sw.Write(TextBox3.Text)
            sw.Close()
        Catch
        End Try
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        ComboBox1.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Url.ToString
    End Sub

    Private Sub TabControl1_MouseEnter(sender As Object, e As EventArgs) Handles TabControl1.MouseEnter
        Timer4.Start()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Try
            CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoBack()
        Catch
        End Try
    End Sub

    Private Sub HTMLEditorToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoBack()
        Catch
        End Try
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoForward()
        Catch
        End Try
    End Sub

    Private Sub SearshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearshToolStripMenuItem.Click
        Try
            CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate(ComboBox1.Text)
        Catch
        End Try
    End Sub
End Class

