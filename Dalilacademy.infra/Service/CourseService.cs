using Dalilacademy.Core.Service;
using Dalilacademy_.Core.DTOs;
using Dalilacademy_.Core.Exciptions;
using Dalilacademy_.Core.Repository;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dalilacademy.infra.Service
{
    public class CourseService(
        ICourserepository courseRepository,
        IValidator<CreateCourseDTo> validator,
        IValidator<UpdateCourseDto> updateValidator) : ICourseService
    {
        public async Task<PageResult<CourseResponseDTo>> Getpageasync(int page, int pagesize, int? minPrice = null, int? maxPrice = null)
        {
            return await courseRepository.Getpageasync(page, pagesize, minPrice, maxPrice);
        }

        public async Task<int> Countasync()
        {
            return await courseRepository.Countasync();
        }
        public async Task<CourseResponseDTo?> GetByIdasync(int id)
        {
            var course = await courseRepository.GetByIdasync(id)
                ?? throw new NotFoundException($"Course {id} was not found.");

            return course;
        }

        public async Task<CourseResponseDTo> Createasync(CreateCourseDTo coursedto)
        {
            await validator.ValidateAndThrowAsync(coursedto);
            return await courseRepository.Createasync(coursedto);
        }

        public async Task<CourseResponseDTo> Updateasync(int id, UpdateCourseDto updatedCourse)
        {
            await updateValidator.ValidateAndThrowAsync(updatedCourse);
            return await courseRepository.Updateasync(id, updatedCourse);
        }

        public async Task<bool> Deleteasync(int id)
        {
            return await courseRepository.Deleteasync(id);
        }
    }
}
