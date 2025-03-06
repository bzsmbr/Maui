﻿namespace Solution.Core.Models.Settings;

public class GoogleDriveSettings: JsonCredentialParameters
{
    [JsonPropertyName("custom_folder")]
    public string CustomFolder {  get; set; }

    [JsonPropertyName("root_folder_id")]
    public string RootFolderId { get; set; }
}
