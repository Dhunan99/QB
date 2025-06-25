using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuestionBank.Application.Contracts.Persistence;

namespace QuestionBank.Infrastructure
{
    public static class InfrastructureServiceRegistry
    {
        public static void AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<QuestionBankDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IQuestionBankDbContext>(provider => provider.GetService<QuestionBankDbContext>());
        }
    }
}
