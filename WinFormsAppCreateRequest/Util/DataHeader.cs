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
                CreateDataGridViewRow(new string[]{ "Host", "mobile.kvpos.com"}),
                CreateDataGridViewRow(new string[]{ "content-type", "application/json"}),
                CreateDataGridViewRow(new string[]{ "unixtimestamp", "1683691947"}),
                CreateDataGridViewRow(new string[]{ "devicetype", "4"}),
                CreateDataGridViewRow(new string[]{ "authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6InNCeCJ9.eyJpc3MiOiJrdnNzand0Iiwic3ViIjoyMjksImlhdCI6MTY5ODY0ODAyMCwiZXhwIjoxNjk5ODU3NjIwLCJwcmVmZXJyZWRfdXNlcm5hbWUiOiJhZG1pbiIsInJvbGVzIjpbIlVzZXIiXSwia3Zzb3VyY2UiOiJSZXRhaWwiLCJrdnVzZXRmYSI6MCwia3Z3YWl0b3RwIjowLCJrdnNlcyI6IjNjZTMxZTgyM2Q3YzQ1NzQ4ODY5OTEwZDliNjZmODQzIiwia3Z1aWQiOjIyOSwia3ZsYW5nIjoidmktVk4iLCJrdnV0eXBlIjowLCJrdnVsaW1pdCI6IkZhbHNlIiwia3Z1YWRtaW4iOiJUcnVlIiwia3Z1YWN0IjoiVHJ1ZSIsImt2dWxpbWl0dHJhbnMiOiJGYWxzZSIsImt2dXNob3dzdW0iOiJUcnVlIiwia3ZiaWQiOjIyMiwia3ZyaW5kaWQiOjAsImt2cmNvZGUiOiJ2bnEiLCJrdnJpZCI6MTIzNiwia3Z1cmlkIjoxMjM2LCJrdnJnaWQiOjEsInBlcm1zIjoiIn0.QcJYSRpPmfnrDeYwmHrl6SfYs1d6Yedabppq3UutgsBRzkViRiBRs-oTbwCOju3SKmWXFOi_QErjZtzs5FMGUZs44LC7QDmDEGJDVNp1b8-CwF6lj3UWBc9z5cF3IhUQjj3LNOJ0Zan28UMiYVNKGU4OU7nwrVeD8RkctVj4dIj1m4miOk8rN7w2cd9LsawZKG-T8UITzIfuJjC0teREQNmqTuIT6LNAtDuad0CgsEmViYERNSmdVfWMm587AKKOuXmU6Bc_TJckf0Cg5Xo5NiIgrlT-tNWnxgwKSAOF0P1UBhJsy9HiFp19drRnQYRBRokCPJN7o20xxqnQkHuZQA"}),
                CreateDataGridViewRow(new string[]{ "retailer", "vnq"}),
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
