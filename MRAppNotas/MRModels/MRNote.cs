﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MRAppNotas.MRModels
{
    internal class MRNote
    {
        public string Filename { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public MRNote()
        {
            Filename = $"{Path.GetRandomFileName()}.notes.txt";
            Date = DateTime.Now;
            Text = "";
        }

        public void Save() =>
            File.WriteAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename), Text);

        public void Delete() =>
            File.Delete(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename));

        public static MRNote Load(string filename)
        {
            filename = System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);

            if (!File.Exists(filename))
                throw new FileNotFoundException("No es posible encontrar esta nota en el dispositivo.", filename);

            return
                new MRNote
                {
                    Filename = Path.GetFileName(filename),
                    Text = File.ReadAllText(filename),
                    Date = File.GetLastWriteTime(filename)
                };
        }

        public static IEnumerable<MRNote> LoadAll()
        {
            string appDataPath = FileSystem.AppDataDirectory;
            return Directory

                    .EnumerateFiles(appDataPath, "*.notes.txt")

                    .Select(filename => MRNote.Load(Path.GetFileName(filename)))

                    .OrderByDescending(note => note.Date);
        }
    }
}
