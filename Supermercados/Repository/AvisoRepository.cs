﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AvisoRepository.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AvisoServices.Models;
using System;

namespace AvisoRepository.Repository
{
    public class AvisoRepository : IAvisoRepository
    {
        private readonly AvisoContexto _context;

        public AvisoRepository(AvisoContexto context)
        {
            _context = context;
          
        }

        public IEnumerable<Aviso> GetAvisoItems()
        {
            return _context.AvisoItems.ToList();
        }
        public void AddAvisoItems(Aviso items)
        {
            _context.AvisoItems.Add(items);
            _context.SaveChanges();

        }

    }
    
}