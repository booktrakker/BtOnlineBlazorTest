using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class ImageFolder
{
    public int ImageFolderId { get; set; }

    public string Email { get; set; } = null!;

    public string Folder { get; set; } = null!;

    public DateTime Timestamp { get; set; }
}
