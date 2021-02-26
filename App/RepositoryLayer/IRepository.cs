using System;
using System.Collections;
using System.Collections.Generic;

namespace RepositoryLayer
{
   public interface IRepository<Nobel> 
    {
        Nobel GetAll();

        Nobel GetByID(int id);
    }
}
