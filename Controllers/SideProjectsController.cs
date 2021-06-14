using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ys_j.Models;

namespace ys_j.Controllers
{

    [Authorize]
    public class SideProjectsController : BaseController
    {
        public IActionResult Index()
        {
            var CompanyDAO = new CompanyDAO();
            var JobDAO = new JobDAO();
            //取出所有公司
            var companies = CompanyDAO.GetAll();
            foreach (var c in companies)
            {
                c.jobs = JobDAO.GetAllByCode(c.code);
                c.jobCount = c.jobs.Count();
                c.areaCount = c.jobs.Select(x => x.area).Distinct().Count();
                c.titleLabelCount = c.jobs.Select(x => x.titleLabel).Distinct().Count();

                c.titleLabelStatistics = c.jobs.GroupBy(x => x.titleLabel).Select(group => new GroupByItem
                {
                    key = group.Key,
                    count = group.Count(),
                    percentage = Math.Round( (double)group.Count()/ (double)c.jobCount *100,2  )
                }).OrderByDescending(x => x.count).Take(3).ToList();
                c.areaStatistics = c.jobs.GroupBy(x => x.area).Select(group => new GroupByItem
                {
                    key = group.Key,
                    count = group.Count(),
                    percentage = Math.Round((double)group.Count() / (double)c.jobCount * 100, 2)
                }).OrderByDescending(x => x.count).Take(3).ToList();
                c.workExpStatistics = c.jobs.GroupBy(x => x.workExp).Select(group => new GroupByItem
                {
                    key = group.Key,
                    count = group.Count(),
                    percentage = Math.Round((double)group.Count() / (double)c.jobCount * 100, 2)
                }).OrderByDescending(x => x.count).Take(3).ToList();
                c.educationStatistics = c.jobs.GroupBy(x => x.education).Select(group => new GroupByItem
                {
                    key = group.Key,
                    count = group.Count(),
                    percentage = Math.Round((double)group.Count() / (double)c.jobCount * 100, 2)
                }).OrderByDescending(x => x.count).Take(3).ToList();

                c.payInfoStatistics = c.jobs.GroupBy(x => x.payInfo).Select(group => new GroupByItem
                {
                    key = group.Key,
                    count = group.Count(),
                    percentage = Math.Round((double)group.Count() / (double)c.jobCount * 100, 2)
                }).OrderByDescending(x => x.count).Take(3).ToList();

                c.applyRangeInfoStatistics = c.jobs.GroupBy(x => x.applyRangeInfo).Select(group => new GroupByItem
                {
                    key = group.Key,
                    count = group.Count(),
                    percentage = Math.Round((double)group.Count() / (double)c.jobCount * 100, 2)
                }).OrderByDescending(x => x.count).Take(3).ToList();

            }

            ViewBag.companies = companies;
            return View();
        }

    }








}
