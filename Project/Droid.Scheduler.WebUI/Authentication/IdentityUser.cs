﻿using System;
using System.Collections.Generic;

namespace Droid.Scheduler.WebUI.Context
{
    public class IdentityUser : IdentityUser<Guid>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IdentityUser"/>.
        /// </summary>
        /// <remarks>
        /// The Id property is initialized to from a new GUID string value.
        /// </remarks>
        public IdentityUser()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="IdentityUser"/>.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <remarks>
        /// The Id property is initialized to from a new GUID string value.
        /// </remarks>
        public IdentityUser(string userName) : this()
        {
            UserName = userName;
        }
    }

    /// <summary>
    /// Represents a user in the identity system
    /// </summary>
    /// <typeparam name="TKey">The type used for the primary key for the user.</typeparam>
    public class IdentityUser<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IdentityUser{TKey}"/>.
        /// </summary>
        public IdentityUser() { }

        /// <summary>
        /// Initializes a new instance of <see cref="IdentityUser{TKey}"/>.
        /// </summary>
        /// <param name="userName">The user name.</param>
        public IdentityUser(string userName) : this()
        {
            UserName = userName;
        }

        /// <summary>
        /// </summary>
        /// Gets or sets the primary key for this user.
        public virtual TKey Id { get; set; }

        /// <summary>
        /// Gets or sets the user name for this user.
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// Gets or sets a salted and hashed representation of the password for this user.
        /// </summary>
        public virtual string PasswordHash { get; set; }

        /// <summary>
        /// A random value that must change whenever a users credentials change (password changed, login removed)
        /// </summary>
        public virtual string SecurityStamp { get; set; }
        
        /// <summary>
        /// Gets or sets the email address for this user.
        /// </summary>
        public virtual string Email { get; set; }


        /// <summary>
        /// Gets or sets a flag indicating if a user has confirmed their email address.
        /// </summary>
        /// <value>True if the email address has been confirmed, otherwise false.</value>
        public virtual bool EmailConfirmed { get; set; }

        

        /// <summary>
        /// Gets or sets a telephone number for the user.
        /// </summary>
        public virtual string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if a user has confirmed their telephone address.
        /// </summary>
        /// <value>True if the telephone number has been confirmed, otherwise false.</value>
        public virtual bool PhoneNumberConfirmed { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if two factor authentication is enabled for this user.
        /// </summary>
        /// <value>True if 2fa is enabled, otherwise false.</value>
        public virtual bool TwoFactorEnabled { get; set; }

        /// <summary>
        /// Gets or sets the date and time, in UTC, when any user lockout ends.
        /// </summary>
        /// <remarks>
        /// A value in the past means the user is not locked out.
        /// </remarks>
        public virtual DateTimeOffset? LockoutEnd { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if this user is locked out.
        /// </summary>
        /// <value>True if the user is locked out, otherwise false.</value>
        public virtual bool LockoutEnabled { get; set; }

        /// <summary>
        /// Gets or sets the number of failed login attempts for the current user.
        /// </summary>
        public virtual int AccessFailedCount { get; set; }
        
        /// <summary>
        /// A random value that must change whenever a user is persisted to the store
        /// </summary>
        public virtual string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Navigation property for the roles this user belongs to.
        /// </summary>
        public virtual ICollection<IdentityUserRole<TKey>> Roles { get; } = new List<IdentityUserRole<TKey>>();

        /// <summary>
        /// Navigation property for the claims this user possesses.
        /// </summary>
        public virtual ICollection<IdentityUserClaim<TKey>> Claims { get; } = new List<IdentityUserClaim<TKey>>();

        /// <summary>
        /// Navigation property for this users login accounts.
        /// </summary>
        public virtual ICollection<IdentityUserLogin<TKey>> Logins { get; } = new List<IdentityUserLogin<TKey>>();

        /// <summary>
        /// Returns the username for this user.
        /// </summary>
        public override string ToString()
        {
            return UserName;
        }
    }
}