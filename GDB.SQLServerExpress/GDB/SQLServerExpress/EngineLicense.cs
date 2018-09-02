namespace GDB.SQLServerExpress
{
    using ESRI.ArcGIS.esriSystem;
    using System;

    public class EngineLicense
    {
        private IAoInitialize m_AoInitialize;

        public EngineLicense()
        {
            try
            {
                this.m_AoInitialize = new AoInitializeClass();
            }
            catch (Exception)
            {
            }
        }

        private esriLicenseStatus CheckOutLicenses(esriLicenseProductCode productCode)
        {
            esriLicenseStatus status = this.m_AoInitialize.IsProductCodeAvailable(productCode);
            if (status == esriLicenseStatus.esriLicenseAvailable)
            {
                status = this.m_AoInitialize.Initialize(productCode);
            }
            return status;
        }

        public bool InitEngineLicense()
        {
            bool flag = true;
            if (this.m_AoInitialize == null)
            {
                return false;
            }
            if (this.CheckOutLicenses(esriLicenseProductCode.esriLicenseProductCodeAdvanced) != esriLicenseStatus.esriLicenseCheckedOut)
            {
                flag = false;
            }
            return flag;
        }

        private string LicenseMessage(esriLicenseStatus licenseStatus)
        {
            string str = "";
            if (licenseStatus == esriLicenseStatus.esriLicenseNotInitialized)
            {
                return "You are not licensed to run this product!";
            }
            if (licenseStatus == esriLicenseStatus.esriLicenseUnavailable)
            {
                return "There are insuffient licenses to run!";
            }
            if (licenseStatus == esriLicenseStatus.esriLicenseFailure)
            {
                return "Unexpected license failure! Please contact your administrator.";
            }
            if (licenseStatus == esriLicenseStatus.esriLicenseAlreadyInitialized)
            {
                str = "The license has already been initialized! Please check your implementation.";
            }
            return str;
        }

        public void ShutdownLicense()
        {
            if (this.m_AoInitialize != null)
            {
                try
                {
                    this.m_AoInitialize.Shutdown();
                }
                catch
                {
                }
                this.m_AoInitialize = null;
            }
        }
    }
}

