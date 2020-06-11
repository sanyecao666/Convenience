﻿using Convience.Entity.Entity.WorkFlows;
using System.Collections.Generic;

namespace Convience.Model.Models.WorkFlowManage
{
    public class FormViewModel
    {
        public int? Id { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public string Background { get; set; }

        public int WorkFlowId { get; set; }
    }

    public class FormResult : FormViewModel { }


    public class FormControlViewModel
    {
        public int? Id { get; set; }

        public int WorkFlowId { get; set; }

        public string Name { get; set; }

        public ControlTypeEnum ControlType { get; set; }

        public string DomId { get; set; }

        public int Top { get; set; }

        public int Left { get; set; }

        public int Width { get; set; }

        public int FontSize { get; set; }

        public string Content { get; set; }

        public int? Line { get; set; }

        public string Options { get; set; }

        public bool? IsRequired { get; set; }

        public string Parttern { get; set; }

        public string MaxLength { get; set; }
    }

    public class FormControlResult : FormControlViewModel { }

    public class WorkFlowFormViewModel
    {

        public int WorkFlowId { get; set; }

        public FormViewModel FormViewModel { get; set; }

        public IEnumerable<FormControlViewModel> FormControlViewModels { get; set; }
    }

    public class WorkFlowFormResult
    {
        public FormResult FormResult { get; set; }

        public IEnumerable<FormControlResult> FormControlResults { get; set; }
    }
}
