/*
	Copyright (c) 2017, pGina Team
	All rights reserved.

	Redistribution and use in source and binary forms, with or without
	modification, are permitted provided that the following conditions are met:
		* Redistributions of source code must retain the above copyright
		  notice, this list of conditions and the following disclaimer.
		* Redistributions in binary form must reproduce the above copyright
		  notice, this list of conditions and the following disclaimer in the
		  documentation and/or other materials provided with the distribution.
		* Neither the name of the pGina Team nor the names of its contributors
		  may be used to endorse or promote products derived from this software without
		  specific prior written permission.

	THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
	ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
	WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
	DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY
	DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
	(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
	LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
	ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
	(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
	SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using pGina.Shared.Settings;

namespace pGina.Plugin.Ldap
{
    class Settings
    {

        public static dynamic Store
        {
            get { return m_settings; }
        }
        private static dynamic m_settings;

        static Settings()
        {
            m_settings = new pGinaDynamicSettings(LdapPlugin.LdapUuid);

            // Set default values for settings (if not already set)
            //Drupal
            m_settings.SetDefault("LdapHost", new string[] { "ldap.foxpass.com" });
            m_settings.SetDefault("LdapPort", 636);
            m_settings.SetDefault("LdapTimeout", 30);
            m_settings.SetDefault("UseSsl", false);
            m_settings.SetDefault("UseTls", false);
            m_settings.SetDefault("RequireCert", false);
            m_settings.SetDefault("ServerCertFile", "");
            m_settings.SetDefault("UseAuthBindForAuthzAndGateway", false);
            m_settings.SetDefault("SearchDN", "cn=<binder-name>,dc=foxpass,dc=com");
            m_settings.SetDefaultEncryptedSetting("SearchPW", "");
            //m_settings.SetDefault("GroupDnPattern", "cn=%g,ou=Group,dc=foxpass,dc=com");
            //m_settings.SetDefault("GroupMemberAttrib", "memberUid");
            m_settings.SetDefault("AttribConv", new string[] { });

            // Authentication
            m_settings.SetDefault("AllowEmptyPasswords", false);
            m_settings.SetDefault("DnPattern", "uid=%u,dc=foxpass,dc=com");
            m_settings.SetDefault("DoSearch", false);
            m_settings.SetDefault("SearchFilter", "");
            m_settings.SetDefault("SearchContexts", new string[] { });
            m_settings.SetDefault("textBoxAPI", "<API_KEY>");
            m_settings.SetDefault("ApiHostUri", "https://api.foxpass.com");

            // Authorization
            //m_settings.SetDefault("GroupAuthzRules", new string[] { (new GroupAuthzRule(true)).ToRegString() });
            m_settings.SetDefault("GroupAuthzRules", new string[] { });
            m_settings.SetDefault("AuthzRequireAuth", true); ///Drupal
            m_settings.SetDefault("AuthzAllowOnError", true);
            m_settings.SetDefault("AuthzDefault", true);

            // Gateway
            //List<string> strList = new List<string>();
            //strList.Add("2\t0\t\t\tS-1-5-32-544");
            //Settings.Store.GroupGatewayRules = strList.ToArray();

            List<string> strList = new List<string>();
            strList.Add("0\t0\tcn=Windows-Administrators,ou=groups,dc=foxpass,dc=com\t(&(member=uid=%u,ou=people,dc=foxpass,dc=com))\tS-1-5-32-544");

            ///Drupal tp add user in group Users
            strList.Add("1\t0\tcn=Windows-Administrators,ou=groups,dc=foxpass,dc=com\t(&(member=uid=%u,ou=people,dc=foxpass,dc=com))\tS-1-5-32-545");
            Settings.Store.GroupGatewayRules = strList.ToArray();
            // m_settings.SetDefault("GroupGatewayRules", new string[] { });

            // Change password
            m_settings.SetDefault("ChangePasswordAttributes", new string[] { });
        }
    }
}
