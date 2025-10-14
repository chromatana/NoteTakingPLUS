using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Note_Taker_Plus.Models
{
    public class Note
    {
        private StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        public string Filename { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;

        public Note()
        {
            Filename = "notes" + DateTime.Now.ToBinary().ToString() + ".txt"; //generates a unique name based on current time (converts to binary) || will change this
        }

        public async Task SaveAsync()
        {
            Console.WriteLine("Hit");
            StorageFile noteFile = (StorageFile)await storageFolder.TryGetItemAsync(Filename);
            if (noteFile is null)
            {
                noteFile = await storageFolder.CreateFileAsync(Filename, CreationCollisionOption.ReplaceExisting);
            }
            await FileIO.WriteTextAsync(noteFile, Text);
        }

        public async Task DeleteAsync()
        {
            StorageFile noteFile = (StorageFile)await storageFolder.TryGetItemAsync(Filename);
            if (noteFile is not null)
            {
                await noteFile.DeleteAsync();
            }
        }
    }
}
