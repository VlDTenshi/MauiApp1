using MauiApp1.Api.Data;
using MauiApp1.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MauiApp1.Api
{
    //public class AuthService(DataContext context, TokenService tokenService, PasswordService passwordService)
    //{
    //    private readonly DataContext _context = context;
    //    private readonly TokenService _tokenService = tokenService;
    //    private readonly PasswordService _passwordService = passwordService;
    //    public async Task<ResultWithDataDto<AuthResponseDto>> SignUpAsync(SignUpRequestDto dto)
    //    {
    //        if (await _context.Users.AsNoTracking().AnyAsync(o => o.Email == dto.Email))
    //        {
    //            return ResultWithDataDto<AuthResponseDto>.Failure("Email already exists");
    //        }

    //        var user = new User
    //        {
    //            Email = dto.Email,
    //            Address = dto.Address,
    //            Name = dto.Name,
    //        };

    //        (user.Salt, user.Hash) = _passwordService.GenerateSaltAndHash(dto.Password);

    //        try
    //        {
    //            await _context.Users.AddAsync(user);
    //            await _context.SaveChangesAsync();
    //            return GenerateAuthResponse(user);
    //        }
    //        catch (Exception ex)
    //        {
    //            return ResultWithDataDto<AuthResponseDto>.Failure(ex.Message);
    //        }
    //    }

    //    public async Task<ResultWithDataDto<AuthResponseDto>> SignInAsync(SignInRequestDto dto)
    //    {
    //        var dbUser = await _context.Users.AsNoTracking()
    //                                        .FirstOrDefaultAsync(o => o.Email == dto.Email);
    //        if (dbUser is null)
    //          return ResultWithDataDto<AuthResponseDto>.Failure("User does't exist");

    //        if (!_passwordService.IsEqual(dto.Password, dbUser.Salt, dbUser.Hash))
    //            return ResultWithDataDto<AuthResponseDto>.Failure("Incorrect password");

    //        return GenerateAuthResponse(dbUser);
    //    }


    //    private ResultWithDataDto<AuthResponseDto> GenerateAuthResponse(User user)
    //    {
    //        var loggedInUser = new LoggedInUser(user.Id, user.Name, user.Email, user.Address);
    //        var token = _tokenService.GenerateJwt(loggedInUser);

    //        var authResponse = new AuthResponseDto(loggedInUser, token);

    //        return ResultWithDataDto<AuthResponseDto>.Success(authResponse);
    //    }
    //} 
}
