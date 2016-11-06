package be.pxl.vegisens;

import org.junit.*;
import org.junit.runner.*;
import org.springframework.beans.factory.annotation.*;
import org.springframework.boot.test.autoconfigure.web.servlet.*;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.mock.mockito.*;
import org.springframework.http.MediaType;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.security.test.context.support.WithMockUser;

import be.pxl.vegisens.domain.GrowableItem;
import be.pxl.vegisens.domain.Humidity;
import be.pxl.vegisens.domain.SensorType;
import be.pxl.vegisens.domain.Temperature;
import be.pxl.vegisens.service.interfaces.IGrowableItemService;
import be.pxl.vegisens.service.interfaces.ISensorTypeService;

import static org.mockito.BDDMockito.*;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.*;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.*;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * Created by aless on 2/11/2016.
 */

// Testing the controller layer

@SpringBootTest(classes = VegiSensApplication.class)
@RunWith(SpringRunner.class)
//Often @WebMvcTest will be limited to a single controller and used in combination with @MockBean to provide mock implementations for required collaborators.
//You can also auto-configure MockMvc in a non-@WebMvcTest (e.g. SpringBootTest) by annotating it with @AutoConfigureMockMvc.
@AutoConfigureMockMvc
public class WebMvcControllerTest 
{

    	//@WithMockUser -> For Authentication
	    // http://docs.spring.io/spring-boot/docs/current/reference/html/boot-features-testing.html      
    	@Autowired
    	private MockMvc mockMVC;
        	  
        @MockBean
        private IGrowableItemService mockGrowableItemService;
                  
        @Test
        @WithMockUser(username="arno", password="pxl", roles={"ADMIN"})
        public void getGrowableItemById_ThroughControllerMapping() throws Exception 
        {            
        	GrowableItem growableExpectedItem = new GrowableItem();
        	growableExpectedItem.setName("Cabbage");
        	growableExpectedItem.setHumidity(new Humidity());
        	growableExpectedItem.setTemperature(new Temperature());
        	
            given(mockGrowableItemService.getGrowableItemById(1)).willReturn(growableExpectedItem);
            
           mockMVC.perform(get("/growableItems/1").accept(MediaType.APPLICATION_JSON))
                    .andExpect(status().isOk())
                    .andExpect(content().json("{'name':'Cabbage'}"));                           
        }
        
        @Test
        @WithMockUser(username="arno", password="pxl", roles={"ADMIN"})
        public void getAllGrowableItems_ThroughControllerMapping() throws Exception 
        {
        	GrowableItem growableExpectedItem1 = new GrowableItem();
        	growableExpectedItem1.setName("Cabbage");
        	growableExpectedItem1.setHumidity(new Humidity());
        	growableExpectedItem1.setTemperature(new Temperature());
            
        	GrowableItem growableExpectedItem2 = new GrowableItem();
        	growableExpectedItem2.setName("Tomato");
        	growableExpectedItem2.setHumidity(new Humidity());
        	growableExpectedItem2.setTemperature(new Temperature());
            
            List<GrowableItem> expectedItems = Arrays.asList(growableExpectedItem1, growableExpectedItem2);
            	
            given(mockGrowableItemService.getAllGrowableItems()).willReturn(expectedItems);
            
           mockMVC.perform(get("/growableItems").accept(MediaType.APPLICATION_JSON))
                    .andExpect(status().isOk())
                    .andExpect(content().json("[{'name':'Cabbage'}, {'name':'Tomato'}]"));  
        }
        
        @MockBean
        private ISensorTypeService mockSensorTypeService;
        
        @Test
        @WithMockUser(username="arno", password="pxl", roles={"ADMIN"})
        public void getSensorTypeById_ThroughControllerMapping() throws Exception 
        {
            SensorType expectedItem = new SensorType();
            expectedItem.setSensortypeUnit("%");
            
            given(mockSensorTypeService.getSensorTypeById(1)).willReturn(expectedItem);

            mockMVC.perform(get("/sensortypes/1").accept(MediaType.APPLICATION_JSON))
                    .andExpect(status().isOk())
                    .andExpect(content().json("{'sensorUnit':'%'}"));
            
        }
        
        @Test
        @WithMockUser(username="arno", password="pxl", roles={"ADMIN"})
        public void getAllSensorTypes_ThroughControllerMapping() throws Exception 
        {
            SensorType expectedItem1 = new SensorType();
            expectedItem1.setSensortypeUnit("%");
            
            SensorType expectedItem2 = new SensorType();
            expectedItem2.setSensortypeUnit("°C");
            
            List<SensorType> expectedItems = Arrays.asList(expectedItem1, expectedItem2);
            	
            given(mockSensorTypeService.getAllSensorTypes()).willReturn(expectedItems);

            mockMVC.perform(get("/sensortypes").accept(MediaType.APPLICATION_JSON))
                    .andExpect(status().isOk())
                    .andExpect(content().json("[{'sensorUnit':'%'},{'sensorUnit':'°C'}]"));
        }
}