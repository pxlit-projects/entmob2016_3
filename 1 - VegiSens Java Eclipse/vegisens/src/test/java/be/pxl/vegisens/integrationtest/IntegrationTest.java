package be.pxl.vegisens.integrationtest;

import static org.junit.Assert.*;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.web.client.TestRestTemplate;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.http.converter.json.MappingJackson2HttpMessageConverter;
import org.springframework.security.test.context.support.WithMockUser;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.util.LinkedMultiValueMap;
import org.springframework.util.MultiValueMap;

import be.pxl.vegisens.domain.GrowableItem;
import be.pxl.vegisens.domain.Humidity;
import be.pxl.vegisens.domain.Temperature;

@RunWith(SpringRunner.class)
@SpringBootTest(webEnvironment = SpringBootTest.WebEnvironment.DEFINED_PORT)
public class IntegrationTest 
{

	@Autowired
    private TestRestTemplate restTemplate;

    @Test
    @WithMockUser(username="arno", password="pxl", roles={"ADMIN"})
    public void createGrowableItem()
    {
   	    
    	GrowableItem newGrowableItem = new GrowableItem();
    	newGrowableItem.setDescription("new vegetable");
    	newGrowableItem.setHumidity(new Humidity());
    	newGrowableItem.setTemperature(new Temperature());
    	newGrowableItem.setName("new name");
    	newGrowableItem.setImage("new image");
 	  
        ResponseEntity<GrowableItem> responseEntity = restTemplate.postForEntity("/growableItems/add", newGrowableItem, GrowableItem.class);
        GrowableItem item = responseEntity.getBody();

        assertEquals(HttpStatus.CREATED, responseEntity.getStatusCode());
        assertEquals("new name", item.getName());
        
    }
}
