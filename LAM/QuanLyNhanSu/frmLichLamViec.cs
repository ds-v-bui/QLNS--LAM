using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Scheduler.Dialogs;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
//using Telerik.Examples.WinControls.DataSources.SchedulerDataSetTableAdapters;
//using Telerik.Examples.WinControls.DataSources;
using QuanLyNhanSu.SchedulerDatasetTableAdapters;
using Telerik.WinControls.Enumerations;
using QuanLyNhanSu.Class;
namespace QuanLyNhanSu
{
	public partial class frmLichLamViec : RadForm
	{

        sql sql = new sql();

        private SchedulerDataset schedulerDataSet = null;
        public frmLichLamViec()
		{
            
            //SqlConnection con = frmMain.me.sql.connectSQL();
            //con.Open();
            //SqlCommand
            //con.Close();
			InitializeComponent();
            this.radSchedulerDemo.GetDayView().DayCount = 1;
            this.radSchedulerNavigator1.ShowWeekendStateChanged += new StateChangedEventHandler(radSchedulerNavigator1_ShowWeekendStateChanged);
            this.radCalendar1.ShowOtherMonthsDays = false;
			this.radCalendar1.AllowMultipleSelect = false;
            this.radCalendar1.TitleFormat = "MMMM";
            
            this.radCalendar1.SelectedDate = DateTime.Today;
			this.radCalendar1.SelectionChanged += new EventHandler(radCalendar1_SelectionChanged);
            //this.cmbTheme.SelectedIndexChanged += new EventHandler(cmbTheme_SelectedIndexChanged);
            this.Load += new EventHandler(Form1_Load);
            this.radSchedulerDemo.PropertyChanged += new PropertyChangedEventHandler(radScheduler1_PropertyChanged);
            this.radSchedulerDemo.Appointments.CollectionChanged += new Telerik.WinControls.Data.NotifyCollectionChangedEventHandler(Appointments_CollectionChanged);
        }

        
        
        void Form1_Load(object sender, EventArgs e)
        {
            this.radCalendar1.InvalidateCalendar();
            BindToDataSet();
        }


        private void BindToDataSet()
        {
            if (this.schedulerDataSet == null)
            {
                this.schedulerDataSet = new SchedulerDataset();

                AppointmentsTableAdapter appointmentsAdapter = new AppointmentsTableAdapter();
                appointmentsAdapter.Fill(this.schedulerDataSet.Appointments);

                ResourcesTableAdapter resourcesAdapter = new ResourcesTableAdapter();
                resourcesAdapter.Fill(this.schedulerDataSet.Resources);

                TransientAppointmentsResourcesTableAdapter appointmentsResourcesAdapter = new TransientAppointmentsResourcesTableAdapter();
                appointmentsResourcesAdapter.Fill(this.schedulerDataSet.TransientAppointmentsResources);
            }

            SchedulerBindingDataSource dataSource = new SchedulerBindingDataSource();
            AppointmentMappingInfo appointmentMappingInfo = new AppointmentMappingInfo();
            appointmentMappingInfo.Start = "Start";
            appointmentMappingInfo.End = "End";
            appointmentMappingInfo.Summary = "Summary";
            appointmentMappingInfo.Description = "Description";
            appointmentMappingInfo.Location = "Location";
            appointmentMappingInfo.BackgroundId = "BackgroundID";
            appointmentMappingInfo.StatusId = "StatusID";
            appointmentMappingInfo.Resources = "Appointments_AppointmentsResources";
            appointmentMappingInfo.ResourceId = "ResourceID";
            appointmentMappingInfo.RecurrenceRule = "RecurrenceRule";

            dataSource.EventProvider.Mapping = appointmentMappingInfo;
            dataSource.EventProvider.DataSource = this.schedulerDataSet.Appointments;

            ResourceMappingInfo resourceMappingInfo = new ResourceMappingInfo();
            resourceMappingInfo.Id = "ID";
            resourceMappingInfo.Name = "ResourceName";

            dataSource.ResourceProvider.Mapping = resourceMappingInfo;
            dataSource.ResourceProvider.DataSource = this.schedulerDataSet.Resources;

            this.radSchedulerDemo.DataSource = dataSource;
        }

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
            this.radSchedulerNavigator1.ThemeName = "ControlDefault";

            //DateTime baseDate = DateTime.Today;
            //DateTime[] start = new DateTime[] { baseDate.AddHours(14.0), baseDate.AddDays(1.0).AddHours(9.0), baseDate.AddDays(2.0).AddHours(13.0) };
            //DateTime[] end = new DateTime[] { baseDate.AddHours(16.0), baseDate.AddDays(1.0).AddHours(15.0), baseDate.AddDays(2.0).AddHours(17.0) };
            //string[] summaries = new string[] { "Mr. Brown", "Mr. White", "Mrs. Green" };
            //string[] descriptions = new string[] { "", "", "" };
            //string[] locations = new string[] { "City", "Out of town", "Service Center" };
            //AppointmentBackground[] backgrounds = new AppointmentBackground[] { AppointmentBackground.Business, AppointmentBackground.MustAttend, AppointmentBackground.Personal };

            //this.radSchedulerDemo.Appointments.BeginUpdate();
            //Appointment appointment = null;
            //for(int i = 0; i < summaries.Length; i++)
            //{
            //    appointment = new Appointment(start[i], end[i], summaries[i], 
            //        descriptions[i], locations[i]);
            //    appointment.Background = backgrounds[i];
            //    this.radSchedulerDemo.Appointments.Add(appointment);
            //}

            //appointment = new Appointment(baseDate.AddHours(11.0), baseDate.AddHours(12.0), "Wash the car", "", "Garage");
            //appointment.RecurrenceRule = new DailyRecurrenceRule(baseDate.AddHours(11.0), 2);
            //this.radSchedulerDemo.Appointments.Add(appointment);
            //this.radSchedulerDemo.Appointments.EndUpdate();
            this.radSchedulerDemo.Resources.Clear();
            this.radSchedulerDemo.Resources.Add(new Resource(1, "Dell Laptop"));
            this.radSchedulerDemo.Resources.Add(new Resource(2, "Lenovo Laptop"));
            this.radSchedulerDemo.Resources.Add(new Resource(3, "Toshiba Laptop"));

            this.InitializeCalendar();

            (this.radSchedulerDemo.ActiveView as SchedulerDayViewBase).RangeFactor = ScaleRange.HalfHour;
            (this.radSchedulerDemo.SchedulerElement.ViewElement as SchedulerDayViewElement).DataAreaElement.ScrollView.Value = Point.Empty;

            for (int i = 0; i < 16; i++)
            {
                (this.radSchedulerDemo.SchedulerElement.ViewElement as SchedulerDayViewElement).DataAreaElement.Table.Scroll(false);
            }

            this.radSchedulerDemo.ActiveViewChanged += new EventHandler<SchedulerViewChangedEventArgs>(radSchedulerDemo_ActiveViewChanged);
		}

        void radSchedulerDemo_ActiveViewChanged(object sender, SchedulerViewChangedEventArgs e)
        {
            if (e.NewView as SchedulerMonthView == null)
            {
                (this.radSchedulerDemo.ActiveView as SchedulerDayViewBase).RangeFactor = ScaleRange.HalfHour;
                (this.radSchedulerDemo.SchedulerElement.ViewElement as SchedulerDayViewElement).DataAreaElement.ScrollView.Value = Point.Empty;

                for (int i = 0; i < 16; i++)
                {
                    (this.radSchedulerDemo.SchedulerElement.ViewElement as SchedulerDayViewElement).DataAreaElement.Table.Scroll(false);
                }

            }
        }

        void Appointments_CollectionChanged(object sender, Telerik.WinControls.Data.NotifyCollectionChangedEventArgs e)
        {

            InitializeCalendar();
            SaveChanges();
            //MessageBox.Show("change");
            //try
            //{
            //    for (int i = 0; i < e.NewItems.Count; i++)
            //    {
                    
            //        MessageBox.Show(e.PropertyName);
            //        MessageBox.Show(e.NewItems[i].ToString());
            //    }
            //}
            //catch
            //{
            //}

        }

        private void InitializeCalendar()
        {
            MultiMonthViewElement viewElement = this.radCalendar1.CalendarElement.CalendarVisualElement as MultiMonthViewElement;

            if (viewElement != null)
            {
                CalendarMultiMonthViewTableElement table = viewElement.GetMultiTableElement();
                
                foreach (MonthViewElement monthView in table.Children)
                {

                    foreach (CalendarCellElement cell in monthView.TableElement.Children)
                    {

                        bool headerCell = (bool)cell.GetValue(CalendarCellElement.IsHeaderCellProperty);
                        if (headerCell)
                            continue;

                        SchedulerDayView view = new SchedulerDayView();
                        view.DayCount = 1;
                        view.StartDate = cell.Date;
                        view.GetViewContainingDate(cell.Date);

                        view.UpdateAppointments(this.radSchedulerDemo.Appointments);


                        if (view.Appointments.Count > 0)
                        {
                            cell.Font = new Font(cell.Font, FontStyle.Bold);
                        }
                        else
                        {
                            cell.Font = this.radCalendar1.Font;
                        }
                    }
                }
            }
        }

        void radScheduler1_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            InitializeCalendar();
        }


		void radCalendar1_SelectionChanged(object sender, EventArgs e)
		{
            this.radSchedulerDemo.ActiveView.StartDate = this.radCalendar1.SelectedDate;
		}

        private void radSchedulerNavigator1_ShowWeekendStateChanged(object sender, StateChangedEventArgs args)
        {
            if (this.radSchedulerDemo.ActiveView as SchedulerMonthView == null)
            {
                (this.radSchedulerDemo.ActiveView as SchedulerDayViewBase).RangeFactor = ScaleRange.HalfHour;
                (this.radSchedulerDemo.SchedulerElement.ViewElement as SchedulerDayViewElement).DataAreaElement.ScrollView.Value = Point.Empty;

                for (int i = 0; i < 16; i++)
                {
                    (this.radSchedulerDemo.SchedulerElement.ViewElement as SchedulerDayViewElement).DataAreaElement.Table.Scroll(false);
                }
            }
        }
        private void radSchedulerDemo_AppointmentEditDialogShowing(object sender, AppointmentEditDialogShowingEventArgs e)
        {
            RadForm form = e.AppointmentEditDialog as RadForm;
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            
            if (e.Appointment.Summary == "")
            {
                e.Appointment.End = DateTime.Now;
                e.Appointment.Start = DateTime.Now;

            }

        }

        void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            //throw new NotImplementedException();
            RadForm form = sender as RadForm;
            DialogResult result = (sender as RadForm).DialogResult;
            if(result==DialogResult.OK)
            {
                if (form.Controls["txtSubject"].Text == "")
                {
                    RadMessageBox.Show("\nSubject không được rỗng !\n", "Thông báo", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    e.Cancel = true;
                }
            }

            
           
        }
        private void SaveChanges()
        {
            AppointmentsTableAdapter appointmentsAdapter = new AppointmentsTableAdapter();
            appointmentsAdapter.Update(this.schedulerDataSet.Appointments);

            TransientAppointmentsResourcesTableAdapter appointmentsResourcesAdapter = new TransientAppointmentsResourcesTableAdapter();
            appointmentsResourcesAdapter.Update(this.schedulerDataSet.TransientAppointmentsResources);
        }



        


	}
}