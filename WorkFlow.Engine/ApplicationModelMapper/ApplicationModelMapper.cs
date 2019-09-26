using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFlow.Engine.ViewModel;
using WorkflowEngine.Repository.Models;

namespace WorkFlow.Engine.ApplicationModelMapper
{
    public class ApplicationModelMapper : Profile
    {
        public ApplicationModelMapper()
        {
            CreateMap<WorkFlowMaster, WorkflowViewModel>()
                .ForMember(dest=>dest.variableViewModels,opt=>opt.MapFrom(src=>src.WorkFlowVariable))
                .ForMember(dest => dest.taskViewModels, opt => opt.MapFrom(src => src.WorkFlowTask));

            CreateMap<WorkFlowMaster, WorkflowViewModel>()
               .ForMember(dest => dest.variableViewModels, opt => opt.MapFrom(src => src.WorkFlowVariable))
               .ForMember(dest => dest.taskViewModels, opt => opt.MapFrom(src => src.WorkFlowTask)).ReverseMap();


            CreateMap<WorkFlowVariable, VariableViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.VariableId, opt => opt.MapFrom(src => src.VariableId))
                .ForMember(dest => dest.WorkFlowId, opt => opt.MapFrom(src => src.WorkFlowId));

            CreateMap<WorkFlowVariable, VariableViewModel>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
               .ForMember(dest => dest.VariableId, opt => opt.MapFrom(src => src.VariableId))
               .ForMember(dest => dest.WorkFlowId, opt => opt.MapFrom(src => src.WorkFlowId)).ReverseMap();


            CreateMap<WorkFlowTask, TaskViewModel>()
                .ForMember(dest => dest.TaskName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId))
                .ForMember(dest => dest.TaskType, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.WorkFlowId, opt => opt.MapFrom(src => src.WorkflowId));

            CreateMap<WorkFlowTask, TaskViewModel>()
             .ForMember(dest => dest.TaskName, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId))
             .ForMember(dest => dest.TaskType, opt => opt.MapFrom(src => src.Type))
             .ForMember(dest => dest.WorkFlowId, opt => opt.MapFrom(src => src.WorkflowId)).ReverseMap();

        }
    }
}
