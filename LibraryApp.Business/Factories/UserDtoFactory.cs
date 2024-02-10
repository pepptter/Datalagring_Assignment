using LibraryApp.Infrastructure.Entities;
using LibraryApp.Business.Dtos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Factories
{
    public static class UserDtoFactory
    {
        public static UserDto Create(UserEntity userEntity)
        {
            if (userEntity == null)
            {
                throw new ArgumentNullException(nameof(userEntity));
            }

            return new UserDto
            {
                UserID = userEntity.UserID,
                FirstName = userEntity.Firstname,
                LastName = userEntity.Lastname,
                Email = userEntity.Email,
                PhoneNumber = userEntity.Phonenumber
            };
        }

        public static UserEntity Create(UserDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }

            return new UserEntity
            {
                UserID = userDto.UserID,
                Firstname = userDto.FirstName,
                Lastname = userDto.LastName,
                Email = userDto.Email,
                Phonenumber = userDto.PhoneNumber
            };
        }
    }
}
