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

import be.pxl.vegisens.application.GrowableItem;
import be.pxl.vegisens.application.IGrowableItemService;
import be.pxl.vegisens.application.ISensorTypeService;
import be.pxl.vegisens.application.SensorType;
import be.pxl.vegisens.application.VegiSensApplication;

import static org.mockito.BDDMockito.*;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.*;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.*;

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
            
            given(mockGrowableItemService.getGrowableItemById(1)).willReturn(growableExpectedItem);
            
            /*mockMVC.perform(get("/growableItems/1").accept(MediaType.APPLICATION_JSON))
                    .andExpect(status().isOk())
                    .andExpect(content().json("{'name':'Cabbage'}"));*/                            
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
}