using Assignment.Models;
using Assignment.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;


namespace Assignment.Controllers
{
    public class ProgramManager
    {
        // Similar codes to Student Manager different variabless
        private DataContext ds = new DataContext();

        public Program createProgram(AddProgram newItem)
        {
            Program program = Mapper.Map<Program>(newItem);
        
            ds.Program.Add(program);
            ds.SaveChanges();
            return program;
        }

        public IEnumerable<ProgramList> getAllPrograms()
        {
            var fetchedObjects = ds.Program.ToList();
            return Mapper.Map<IEnumerable<ProgramList>>(fetchedObjects);
        }


        public ProgramBase GetProgramById(int id)
        {
            var fetchedObject = ds.Program.Find(id);

            if (fetchedObject == null)
            {
                return null;
            }
            else
            {
                return Mapper.Map<ProgramBase>(fetchedObject);
            }
        }
        
        public bool DeleteProgramById(int id)
        {
            var fetchedObject = ds.Program.Find(id);

            if (fetchedObject == null)
            {
                return false;
            }
            else
            {
                ds.Program.Remove(fetchedObject);
                ds.SaveChanges();

                return true;
            }
        }

        public ProgramBase EditProgram(ProgramBase newItem)
        {
            var fetchedObject = ds.Program.Find(newItem.Id);

            if (fetchedObject == null)
            {
                return null;
            }
            else
            {
                ds.Entry(fetchedObject).CurrentValues.SetValues(newItem);
                ds.SaveChanges();
                return Mapper.Map<ProgramBase>(fetchedObject);
            }
        }

    }
}