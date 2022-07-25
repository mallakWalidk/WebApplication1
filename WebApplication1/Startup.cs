using lear.core.domain;
using lear.core.Repoisitory;
using lear.core.service;
using learn.infra.domain;
using learn.infra.Repoisitory;
using learn.infra.service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDBContext, DBcontext>();


            services.AddScoped<Im_category_repoisitory, m_category_repoisitory>();
            services.AddScoped<Im_category_service, m_category_service>();

            services.AddScoped<Im_friends_repoisitory, m_friends_repoisitory>();
            services.AddScoped<Im_friends_service, m_friends_service>();

            services.AddScoped<Im_group_message_repoisitory, m_group_message_repoisitory>();
            services.AddScoped<Im_group_message_service, m_group_message_service>();

            services.AddScoped<Im_groups_repoisitory, m_groups_repoisitory>();
            services.AddScoped<Im_groups_service, m_groups_service>();

            services.AddScoped<Im_groups_users_repoisitory, m_groups_users_repoisitory>();
            services.AddScoped<Im_groups_users_service, m_groups_users_service>();

            services.AddScoped<Im_likes_repoisitory, m_likes_repoisitory>();
            services.AddScoped<Im_likes_service, m_likes_service>();

            services.AddScoped<Im_message_repoisitory, m_message_repoisitory>();
            services.AddScoped<Im_message_service, m_message_service>();

            services.AddScoped<Im_post_repoisitory, m_post_repoisitory>();
            services.AddScoped<Im_post_service, m_post_service>();

            services.AddScoped<Im_purchased_services_repoisitory, m_purchased_services_repoisitory>();
            services.AddScoped<Im_purchased_services_service, m_purchased_services_service>();

            services.AddScoped<Im_service_repoisitory, m_service_repoisitory>();
            services.AddScoped<Im_service_service, m_service_service>();

            services.AddScoped<Im_users_repoisitory, m_users_repoisitory>();
            services.AddScoped<Im_users_service, m_users_service>();

            services.AddScoped<Im_visa_repoisitory, m_visa_repoisitory>();
            services.AddScoped<Im_visa_service, m_visa_service>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }

        ).AddJwtBearer(y =>
        {
            y.RequireHttpsMetadata = false;
            y.SaveToken = true;
            y.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]")),
                ValidateIssuer = false,
                ValidateAudience = false,

            };


        });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
