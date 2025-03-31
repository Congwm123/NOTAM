﻿global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using Newtonsoft.Json;
global using NOTAMApplication.Common.Constants;
global using NOTAMApplication.Common.Errors;
global using NOTAMApplication.DataAccess.Entities;
global using NOTAMApplication.Services.Jobs;
global using NOTAMApplication.Services.Models.RequestModels.User;
global using NOTAMApplication.Services.Models.ResponseModels;
global using NOTAMApplication.Services.Results;
global using NOTAMApplication.Services.Services.Interfaces;
global using Quartz;
global using System.Diagnostics.CodeAnalysis;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;
global using System.Security.Cryptography;
