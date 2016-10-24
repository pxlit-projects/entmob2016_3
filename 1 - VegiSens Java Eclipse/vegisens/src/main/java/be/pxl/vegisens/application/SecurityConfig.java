package be.pxl.vegisens.application;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.authentication.encoding.ShaPasswordEncoder;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;

@Configuration
@EnableWebSecurity
public class SecurityConfig extends WebSecurityConfigurerAdapter 
{
    @Override
    protected void configure(HttpSecurity http) throws Exception
    {

        // Order of authentication matters
        http.authorizeRequests()
                .antMatchers("/growableItems").fullyAuthenticated()
                .antMatchers("/growableItems").access("hasRole('ROLE_ADMIN')")
                .antMatchers("/growableItems/add/").fullyAuthenticated()
                .antMatchers("/growableItems/add/").access("hasRole('ROLE_ADMIN')")
                .anyRequest().authenticated().and().csrf().disable()
                .httpBasic(); // To get authentication popup
    }

    @Autowired
    public void configureSecurity(AuthenticationManagerBuilder auth, javax.sql.DataSource ds /*Error can be ignored*/) throws Exception 
    {
        auth.jdbcAuthentication()
                .passwordEncoder(new ShaPasswordEncoder(256))
                .dataSource(ds)
                .usersByUsernameQuery("select USERNAME, PASSWORD, ENABLED from users where USERNAME = ?")
                .authoritiesByUsernameQuery("select USERNAME, ROLE from users where USERNAME = ?");
    }
}