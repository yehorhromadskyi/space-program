﻿using System;
using System.Collections.Generic;
using Foundation;
using GetCoins.iOS.Models;
using UIKit;

namespace GetCoins.iOS.ViewControllers
{
    public partial class RoverDetailsViewController : UIViewController
    {
        Rover _rover;

        public RoverDetailsViewController(IntPtr handle)
            : base(handle)
        {
        }

		public RoverDetailsViewController() : base("RoverDetailsViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            camerasTableView.Source = new CamerasTableSource(_rover.Cameras);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
		}

        public void SetRover(Rover rover)
        {
            _rover = rover;
        }

		//[Action("SaveRoverDetails:")]
		//public void SaveRoverDetails(UIStoryboardSegue segue)
        //{
		//	Console.WriteLine("Save");
        //}

        public class CamerasTableSource : UITableViewSource
        {
            readonly List<Camera> _cams = new List<Camera>();

            public List<Camera> Cams => _cams;

            public CamerasTableSource(List<Camera> cams)
            {
                _cams = cams;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell("CameraCell");
                var camera = _cams[indexPath.Row];

                if (cell == null)
                {
                    cell = new UITableViewCell(UITableViewCellStyle.Subtitle, "CameraCell");
                }

                cell.TextLabel.Text = camera.Name;
                cell.DetailTextLabel.Text = camera.FullName;

                return cell;
            }

            public override nint RowsInSection(UITableView tableview, nint section) => _cams.Count;
        }
    }
}

