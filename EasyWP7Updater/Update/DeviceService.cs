﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using Microsoft.WindowsMobile.DeviceUpdate;
using System.Runtime.InteropServices;


namespace EasyWP7Updater.Update
{
    class DeviceService : IDisposable
    {
        public static string updateWPPath;

        public delegate void UpdateWPMessageEventhandler(object sender, UpdateMessageEventArgs args);
        public event UpdateWPMessageEventhandler OnUpdateWPMessageSent;

        public delegate void DevicesChangedEventhandler(object sender, List<BindableDeviceInformation> Devices);
        public event DevicesChangedEventhandler OnDevicesChanged;

        private EventHandler<DeviceConnectionChangedEventArgs> changedHandler;

        public List<BindableDeviceInformation> Devices;

        public DeviceService()
        {
            updateWPPath = Path.Combine(Path.GetDirectoryName(new Uri(base.GetType().Assembly.CodeBase).LocalPath), (Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE") == "x86") ? "tools\\x86" : "tools\\x64");
            changedHandler = new EventHandler<DeviceConnectionChangedEventArgs>(manager_DeviceConnectionChanged);
            DeviceManagerSingleton.Manager.DeviceConnectionChanged += changedHandler;
            UpdateDevices();
        }

        void manager_DeviceConnectionChanged(object sender, DeviceConnectionChangedEventArgs e)
        {
            switch (e.ChangeType)
            {
                case DeviceChangeType.DeviceArrival:
                    raiseMessageSent(String.Format("{0} - {1} has been connected", e.DeviceInfo.Name, e.DeviceInfo.UniqueIdentifier), UpdateMessageEventArgs.MessageType.Log);
                    break;
                case DeviceChangeType.DeviceRemoval:
                    raiseMessageSent(String.Format("{0} - {1} has been disconnected", e.DeviceInfo.Name, e.DeviceInfo.UniqueIdentifier), UpdateMessageEventArgs.MessageType.Log);
                    break;
            }

            UpdateDevices();

            if (OnDevicesChanged != null)
                OnDevicesChanged(this, this.Devices);
        }

        public List<BindableDeviceInformation> UpdateDevices()
        {
            Devices = new List<BindableDeviceInformation>();
            IDeviceInfo[] connected = DeviceManagerSingleton.Manager.GetConnectedDeviceInfo();
            foreach (IDeviceInfo info in connected)
            {
                Devices.Add(new BindableDeviceInformation(info));
            }
            return Devices;
        }

        //Does not work, COM Error
        public void UpdateCAB(IDeviceInfo device, List<string> updates, bool withBackup)
        {
            IDevice d = (IDevice)null;
            try
            {
                d = DeviceManagerSingleton.Manager.AcquireDevice(device.UniqueIdentifier);
                if (d != null)
                {
                    raiseMessageSent(String.Format("Applying updates to device {0} ({1})", device.Name, device.UniqueIdentifier), UpdateMessageEventArgs.MessageType.Log);
                    UpdateType type = UpdateType.IU;
                    if (withBackup)
                        type = UpdateType.IU | UpdateType.BACKUP;

                    IErrorInfo error = d.Update(updates.ToArray(), type, new Action<IUpdateProgress>(handleProgress), (object)null);

                    if (error != null)
                    {
                        raiseMessageSent(String.Format("Update on device {0} completed with error {1} - {2}", device.UniqueIdentifier, error.Code.ToString(), error.Description.ToString()), UpdateMessageEventArgs.MessageType.Log); 
                    }

                    DeviceManagerSingleton.Manager.ReleaseDevice(d);
                }
            }
            catch (Exception ex)
            {
                raiseMessageSent(ex.Message, UpdateMessageEventArgs.MessageType.Log);
                if (d != null)
                    DeviceManagerSingleton.Manager.ReleaseDevice(d);
            }
        }

        private void handleProgress(IUpdateProgress progress)
        {
            if (progress.CurrentStep.StepCompleted)
            {
                raiseMessageSent(String.Format("Step {0} completed", progress.CurrentStep.Name));
            }
            else
            {
                if (progress.CurrentStep.PercentageAvailable)
                {
                    raiseMessageSent(String.Format("Step {0}: {1}%", progress.CurrentStep.Name, progress.CurrentStep.Percentage));
                }
                else
                {
                    raiseMessageSent(String.Format("{0} - {1}: working", progress.CurrentStep.Name, DateTime.Now.ToShortTimeString()), UpdateMessageEventArgs.MessageType.Log);
                }
            }
        }

        private void raiseMessageSent(string message)
        {
            if (OnUpdateWPMessageSent != null)
                OnUpdateWPMessageSent(this, new UpdateMessageEventArgs(message));
        }

        private void raiseMessageSent(string message, UpdateMessageEventArgs.MessageType type)
        {
            if (OnUpdateWPMessageSent != null)
                OnUpdateWPMessageSent(this, new UpdateMessageEventArgs(message, type));
        }

        public void Dispose()
        {
            Devices.Clear();
            Devices = null;
            changedHandler = null;
        }

        public static void RestartSLDRMode(IDeviceInfo device)
        {
            string uid = device.UniqueIdentifier;
            IDevice d = DeviceManagerSingleton.Manager.AcquireDevice(uid);
            try
            {
                d.Reboot(OSType.SLDR);
                DeviceManagerSingleton.Manager.ReleaseDevice(d);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                DeviceManagerSingleton.Manager.ReleaseDevice(d);
            }
        }

        public static void RestartOSMode(IDeviceInfo device)
        {
            string uid = device.UniqueIdentifier;
            IDevice d = DeviceManagerSingleton.Manager.AcquireDevice(uid);
            try
            {
                d.Reboot(OSType.MAINOS);
                DeviceManagerSingleton.Manager.ReleaseDevice(d);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                DeviceManagerSingleton.Manager.ReleaseDevice(d);
            }
        }

        public static void RestartColdboot(IDeviceInfo device)
        {
            string uid = device.UniqueIdentifier;
            IDevice d = DeviceManagerSingleton.Manager.AcquireDevice(uid);
            try
            {
                d.Reboot(OSType.COLDBOOT);
                DeviceManagerSingleton.Manager.ReleaseDevice(d);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                DeviceManagerSingleton.Manager.ReleaseDevice(d);
            }
        }
    }
}
