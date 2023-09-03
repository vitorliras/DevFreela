using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.InputModel
{
    public class CreatedCommentInputModel
    {
        public string Content { get; private set; }
        public int IdProject { get; private set; }
        public int IdUser { get; private set; }
    }
}
