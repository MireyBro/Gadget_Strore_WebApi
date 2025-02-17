﻿using System;
using Gadget_Strore_WebApi.Domain.Entities;
using Gadget_Strore_WebApi.Domain.Repositories.Abstract;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Gadget_Strore_WebApi.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository : ITextFieldsRepository
    {
        private readonly AppDbContext context;
        public EFTextFieldsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<TextField> GetTextFields()
        {
            return context.TextFields;
        }
        public TextField GetTextFieldById(Guid id)
        {
            return context.TextFields.FirstOrDefault(x => x.Id == id);
        }
        public TextField GetTextFieldByCodeWord(string codeWord)
        {
            return context.TextFields.FirstOrDefault(x => x.CodeWord == codeWord);
        }
        public void SaveTextField(TextField entity)
        {
            if(entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else 
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();            
        }
        public void DeleteTextField(Guid id)
        {

            context.TextFields.Remove(new TextField() { Id = id });
            context.SaveChanges();
            
        }


    }
}
