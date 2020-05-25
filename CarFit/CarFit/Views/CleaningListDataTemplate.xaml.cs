using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFit.Models;
using CarFit.Services;
using CarFit.SharedLib;
using DryIoc;
using Prism.Services.Dialogs;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.Xaml;
using TaskStatus = CarFit.Models.TaskStatus;
using Prism.Services;

namespace CarFit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CleaningListDataTemplate : ContentView
    {
        private List<TaskStatusMap> _TaskStatusMap;
        private IDialogService _dialogService;
        private IPageDialogService _pageDialogService;

        public CleaningListDataTemplate()
        {
            InitializeComponent();
            _dialogService = App.IoCContainer.Resolve<IDialogService>();
            _pageDialogService = App.IoCContainer.Resolve<IPageDialogService>();

            ICommonService commonService = App.IoCContainer.Resolve<ICommonService>();
            _TaskStatusMap = commonService.GetTaskMapList();

        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            var state = Common.Util.GetWidthState(width);
            VisualStateManager.GoToState(CardlblTitle, state);
            VisualStateManager.GoToState(detailsText, state);
            VisualStateManager.GoToState(Icon1Lbl, state);
            VisualStateManager.GoToState(LblVisitTimeUsed, state);
            VisualStateManager.GoToState(Icon3Lbl, state);
            VisualStateManager.GoToState(Icon4Lbl, state);
            VisualStateManager.GoToState(BtnStatusName, state);
        }

        private async void  BtnStatusName_OnClicked(object sender, EventArgs e)
        {
            
            
            if (sender is Button btn)
            {
                int visitId = Convert.ToInt32(btn.CommandParameter);

                if (this.BindingContext is CarWashTask data)
                {
                    var currentStatus = _TaskStatusMap.Find(o => o.TaskStatus.Name == btn.Text);

                    var newStatuses = _TaskStatusMap.Find(o => o.TaskStatus.Name == btn.Text).TaskStatusMapCollection;
                    if (newStatuses?.Count > 0)
                    {
                        //StatusList.ItemsSource = newStatuses;
                        //_dialogService.ShowDialog(nameof(StatusPopupListView));
                        //StatusPopupListView.IsVisible = true;

                        var selectedStatus = await _pageDialogService.DisplayActionSheetAsync("Select Status", "Cancel", null,
                            newStatuses.Select(o=>o.Name).ToArray());
                        

                        var newStatus = newStatuses.FirstOrDefault(o => o.Name == selectedStatus);
                        if (newStatus != null)
                        {
                            btn.Text = newStatus.Name;
                            //btn.BackgroundColor = System.Drawing.Color.Red;
                            //btn.BackgroundColor = System.Drawing.Color.FromName(newStatus.Color);
                            btn.BackgroundColor = Xamarin.Forms.Color.FromHex(newStatus.Color);

                            if (currentStatus.TaskStatus.Id == SharedLib.TaskStatusEnum.ToDo.ToInt()
                                && newStatus.Id == TaskStatusEnum.InProgress.ToInt()
                            )
                            {
                                data.WorkStartTime = DateTime.Now;
                            }

                            if (currentStatus.TaskStatus.Id == SharedLib.TaskStatusEnum.InProgress.ToInt()
                                && 
                                (
                                    newStatus.Id == TaskStatusEnum.Done.ToInt()
                                    ||
                                    newStatus.Id == TaskStatusEnum.Rejected.ToInt()
                                )
                            )
                            {
                                data.WorkEndTime = DateTime.Now;
                            }

                            if (data.WorkStartTime.HasValue && data.WorkEndTime.HasValue)
                            {
                                TimeSpan taskTime = data.WorkEndTime.GetValueOrDefault().Subtract(data.WorkStartTime.GetValueOrDefault());
                                data.VisitTimeUsed = Convert.ToInt32(taskTime.TotalSeconds);
                                LblVisitTimeUsed.Text = $"{data.VisitTimeUsed.ToString()} Sec" ;
                            }

                            data.TaskStatus = newStatus;

                            this.BindingContext = data;
                        }

                    }



                }

                //btn.BackgroundColor = System.Drawing.Color.FromName(newStatus.Color);
                //if (btn.Parent is PancakeView pn)
                //{
                //    pn.BackgroundColor = System.Drawing.Color.FromName(newStatus.Color);
                //}

            }


        }

        private void StatusList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            StatusPopupListView.IsVisible = false;
            if (e.SelectedItem is TaskStatus newStatus)
            {
                if (this.BindingContext is CarWashTask data)
                {
                    BtnStatusName.Text = newStatus.Name;
                    //btn.BackgroundColor = System.Drawing.Color.Red;
                    //btn.BackgroundColor = System.Drawing.Color.FromName(newStatus.Color);
                    BtnStatusName.BackgroundColor = Xamarin.Forms.Color.FromHex(newStatus.Color);

                    data.TaskStatus = newStatus;
                }
            }
        }
        
    }
}