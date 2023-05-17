using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace WinFormsAppCreateRequest.Util
{
    public class DataHeader
    {
        internal static DataGridViewRow[] InitDataForGridView()
        {
            var a = new int[] { 1, 2 };
            return new DataGridViewRow[]
            {
                CreateDataGridViewRow(new string[]{ "Accept-Encoding", "gzip, deflate, br"}),
                CreateDataGridViewRow(new string[]{ "Connection", "keep-alive"}),
                CreateDataGridViewRow(new string[]{ "Host", "api-mobile3.kiotviet.fun"}),
                CreateDataGridViewRow(new string[]{ "content-type", "application/json"}),
                CreateDataGridViewRow(new string[]{ "unixtimestamp", "1683691947"}),
                CreateDataGridViewRow(new string[]{ "devicetype", "4"}),
                CreateDataGridViewRow(new string[]{ "authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6InNCeCJ9.eyJpc3MiOiJrdnNzand0Iiwic3ViIjoxMDQyLCJpYXQiOjE2ODQyMjI5ODEsImV4cCI6MTY4NjY0MjE4MSwicHJlZmVycmVkX3VzZXJuYW1lIjoiYWRtaW4iLCJyb2xlcyI6WyJVc2VyIl0sImt2c291cmNlIjoiUmV0YWlsIiwia3Z1c2V0ZmEiOjAsImt2d2FpdG90cCI6MCwia3ZzZXMiOiJlYmE2N2NhZjI5OWI0ODEwOTE2MjJjMTZjMzRiNmFmZSIsImt2dWlkIjoxMDQyLCJrdnV0eXBlIjowLCJrdnVsaW1pdCI6IkZhbHNlIiwia3Z1YWRtaW4iOiJUcnVlIiwia3Z1YWN0IjoiVHJ1ZSIsImt2dWxpbWl0dHJhbnMiOiJGYWxzZSIsImt2dXNob3dzdW0iOiJUcnVlIiwia3ZiaWQiOjg0MSwia3ZyaW5kaWQiOjEsImt2cmNvZGUiOiJ0ZXN0ZnVuMSIsImt2cmlkIjo4MjYsImt2dXJpZCI6ODI2LCJrdnJnaWQiOjUsInBlcm1zIjoiIn0.WR98dB1QBDGu5w8w9tiLcjehyDuc6siMfsCSgw00hokGUozK3gG7Vgfdk8bitYYCMsjnsKWtI0metJ_HNZNJzyE0v_Pjhcq1awZhPYVwQSMo9v3Hs3hjFd6v8njEUH1sqLwnAL2KBGq--JNGdS6BhlGmgNlgP8QIkLHzUUPMwcsEg8QIk12O6LVO0sUzISN7nF_9PqWJrvftZtVX9nRT9UcVRizm554T4g93uVHGlPfS5P1M-zvGKQhHj04YtcQq_qEy9-UtWOtlb52ZCmtFKZm3oINOpIjqnXnqaFFWkupvRvbH5c7sRZxZBi712N6nY5Y5RmyQ8gfx3SVTMD7AfQ"}),
                CreateDataGridViewRow(new string[]{ "retailer", "testfun1"}),
                CreateDataGridViewRow(new string[]{ "devicename", "Simulator"}),
                CreateDataGridViewRow(new string[]{ "accept", "/"}),
                CreateDataGridViewRow(new string[]{ "securehash", "14da3d87ecaa41b94a6cc969eb29e7f9a386e6913b9224e45ee5906bd60880b5"}),
                CreateDataGridViewRow(new string[]{ "deviceos", "iOS"}),
                CreateDataGridViewRow(new string[]{ "accept-language", "vi;q=1"}),
                CreateDataGridViewRow(new string[]{ "app", "iOS-pos-1.12.861"}),
                CreateDataGridViewRow(new string[]{ "deviceid", "DE4022E3-75FE-423C-BABA-C35A65B9A848"}),
                CreateDataGridViewRow(new string[]{ "user-agent", "iOS/pos/1.12.861 (build: 20230223.143007; iOS 16.4; model: Simulator; name: iPhone 14 Pro)"})
            };
        }
        
        static DataGridViewRow CreateDataGridViewRow(string[] values)
        {
            DataGridViewRow row = new DataGridViewRow();
            if (values != null && values.Length > 0)
            {
                foreach (var value in values)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = value });
                }
            }
            return row;
        }

        internal static Dictionary<string, string> GetDataHeaderFromView(DataGridViewRowCollection rows)
        {
            var rs = new Dictionary<string, string>();
            foreach(DataGridViewRow row in rows)
            {
                if (!row.IsNewRow) // Skip the new row for data entry
                {
                    string key = row.Cells["Key"].Value?.ToString();
                    string value = row.Cells["Value"].Value?.ToString();
                    rs.Add(key, value);
                }
            }
            return rs;
        }
    }

    public class Header
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
