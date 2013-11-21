﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace nl.fhict.IntelliCloud.Data.Model
{
    /// <summary>
    /// A class representing the relation between a keyword and question.
    /// </summary>
    [Table("QuestionKey")]
    public class QuestionKeyEntity
    {
        /// <summary>
        /// Gets or sets the question the keyword applies to.
        /// </summary>
        [Key, Required]
        public QuestionEntity Question { get; set; }
        
        /// <summary>
        /// Gets or sets the keyword that is linked to the question.
        /// </summary>
        [Key, Required]
        public KeywordEntity Keyword { get; set; }

        /// <summary>
        /// Gets or sets the affinity of the keyword with the question. The affinity is determined by de count of the 
        /// keyword in the question and by the amount of accepts and declines of answers that have this keyword.
        /// </summary>
        public int Affinity { get; set; }
    }
}