using MRAppNotas.MRModels;
using System.Collections.ObjectModel;

namespace MRAppNotas.MRModels;

internal class MRAllNotes
{
    public ObservableCollection<MRNote> Notes { get; set; } = new ObservableCollection<MRNote>();

    public MRAllNotes() =>
        LoadNotes();

    public void LoadNotes()
    {
        Notes.Clear();

        // Get the folder where the notes are stored.
        string appDataPath = FileSystem.AppDataDirectory;

        // Use Linq extensions to load the *.notes.txt files.
        IEnumerable<MRNote> notes = Directory

                                    // Select the file names from the directory
                                    .EnumerateFiles(appDataPath, "*.notes.txt")

                                    // Each file name is used to create a new Note
                                    .Select(filename => new MRNote()
                                    {
                                        Filename = filename,
                                        Text = File.ReadAllText(filename),
                                        Date = File.GetLastWriteTime(filename)
                                    })

                                    // With the final collection of notes, order them by date
                                    .OrderBy(note => note.Date);

        // Add each note into the ObservableCollection
        foreach (MRNote note in notes)
            Notes.Add(note);
    }
}
