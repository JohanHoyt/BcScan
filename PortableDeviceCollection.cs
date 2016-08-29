using PortableDeviceApiLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bcScan
{
    public class PortableDeviceCollection : Collection<PortableDevice>
    {
        private readonly PortableDeviceManager _deviceManager;

        public PortableDeviceCollection()
        {
            this._deviceManager = new PortableDeviceManager();
        }

        public void Refresh()
        {
            this._deviceManager.RefreshDeviceList();

            // Determine how many WPD devices are connected
            var deviceIds = new string[1];
            uint count = 1;
            this._deviceManager.GetDevices(ref deviceIds[0], ref count);

            // Retrieve the device id for each connected device
            deviceIds = new string[count];
            try
            {
                this._deviceManager.GetDevices(ref deviceIds[0], ref count);
            }
            catch (System.IndexOutOfRangeException e)
            {
                MessageBox.Show("Scanner no conectado", "Advertencia", MessageBoxButtons.OK);
            }
            foreach (var deviceId in deviceIds)
            {
                Add(new PortableDevice(deviceId));
            }
        }


    }
}
