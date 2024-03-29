namespace QuanLyNhanSu
{
	partial class frmLichLamViec
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.radPanelCalendar = new Telerik.WinControls.UI.RadPanel();
            this.radCalendar1 = new Telerik.WinControls.UI.RadCalendar();
            this.radSchedulerNavigator1 = new Telerik.WinControls.UI.RadSchedulerNavigator();
            this.radSchedulerDemo = new Telerik.WinControls.UI.RadScheduler();
            ((System.ComponentModel.ISupportInitialize)(this.radPanelCalendar)).BeginInit();
            this.radPanelCalendar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCalendar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSchedulerNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSchedulerDemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanelCalendar
            // 
            this.radPanelCalendar.BackgroundImage = global::QuanLyNhanSu.Properties.Resources.scheduler_cal;
            this.radPanelCalendar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radPanelCalendar.Controls.Add(this.radCalendar1);
            this.radPanelCalendar.Location = new System.Drawing.Point(4, 6);
            this.radPanelCalendar.Name = "radPanelCalendar";
            this.radPanelCalendar.Size = new System.Drawing.Size(250, 600);
            this.radPanelCalendar.TabIndex = 9;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPanelCalendar.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanelCalendar.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // radCalendar1
            // 
            this.radCalendar1.AllowMultipleView = true;
            this.radCalendar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radCalendar1.CellAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radCalendar1.HeaderHeight = 17;
            this.radCalendar1.HeaderWidth = 17;
            this.radCalendar1.Location = new System.Drawing.Point(3, 30);
            this.radCalendar1.Margin = new System.Windows.Forms.Padding(0);
            this.radCalendar1.MultiViewRows = 3;
            this.radCalendar1.Name = "radCalendar1";
            this.radCalendar1.RangeMaxDate = new System.DateTime(2099, 12, 30, 0, 0, 0, 0);
            this.radCalendar1.Size = new System.Drawing.Size(245, 530);
            this.radCalendar1.TabIndex = 1;
            this.radCalendar1.Text = "radCalendar1";
            this.radCalendar1.ThemeName = "ControlDefault";
            this.radCalendar1.TitleAlign = System.Windows.Forms.VisualStyles.ContentAlignment.Center;
            this.radCalendar1.ZoomFactor = 1.2F;
            // 
            // radSchedulerNavigator1
            // 
            this.radSchedulerNavigator1.AssociatedScheduler = this.radSchedulerDemo;
            this.radSchedulerNavigator1.AutoSize = true;
            this.radSchedulerNavigator1.DateFormat = "dd/mm/yyyy";
            this.radSchedulerNavigator1.Location = new System.Drawing.Point(263, 6);
            this.radSchedulerNavigator1.MinimumSize = new System.Drawing.Size(400, 74);
            this.radSchedulerNavigator1.Name = "radSchedulerNavigator1";
            // 
            // 
            // 
            this.radSchedulerNavigator1.RootElement.MinSize = new System.Drawing.Size(400, 74);
            this.radSchedulerNavigator1.RootElement.StretchVertically = false;
            this.radSchedulerNavigator1.Size = new System.Drawing.Size(709, 74);
            this.radSchedulerNavigator1.TabIndex = 8;
            this.radSchedulerNavigator1.ThemeName = "ControlDefault";
            // 
            // radSchedulerDemo
            // 
            this.radSchedulerDemo.AllowAppointmentMove = false;
            this.radSchedulerDemo.AllowAppointmentResize = false;
            this.radSchedulerDemo.BackColor = System.Drawing.Color.White;
            this.radSchedulerDemo.DataSource = null;
            this.radSchedulerDemo.Location = new System.Drawing.Point(263, 84);
            this.radSchedulerDemo.Name = "radSchedulerDemo";
            this.radSchedulerDemo.Size = new System.Drawing.Size(709, 522);
            this.radSchedulerDemo.TabIndex = 0;
            this.radSchedulerDemo.AppointmentEditDialogShowing += new System.EventHandler<Telerik.WinControls.UI.AppointmentEditDialogShowingEventArgs>(this.radSchedulerDemo_AppointmentEditDialogShowing);
            // 
            // frmLichLamViec
            // 
            this.ClientSize = new System.Drawing.Size(984, 614);
            this.Controls.Add(this.radPanelCalendar);
            this.Controls.Add(this.radSchedulerNavigator1);
            this.Controls.Add(this.radSchedulerDemo);
            this.MaximizeBox = false;
            this.Name = "frmLichLamViec";
            this.Text = " Lịch Làm Việc";
            this.ThemeName = "Office2007Blue";
            ((System.ComponentModel.ISupportInitialize)(this.radPanelCalendar)).EndInit();
            this.radPanelCalendar.ResumeLayout(false);
            this.radPanelCalendar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCalendar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSchedulerNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSchedulerDemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Telerik.WinControls.UI.RadScheduler radSchedulerDemo;
        private Telerik.WinControls.UI.RadCalendar radCalendar1;
        private Telerik.WinControls.UI.RadSchedulerNavigator radSchedulerNavigator1;
        private Telerik.WinControls.UI.RadPanel radPanelCalendar;
	}
}