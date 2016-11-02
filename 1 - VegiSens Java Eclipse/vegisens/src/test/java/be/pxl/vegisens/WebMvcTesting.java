package be.pxl.vegisens;

import org.junit.*;
import org.junit.runner.*;
import org.springframework.beans.factory.annotation.*;
import org.springframework.boot.test.autoconfigure.web.servlet.*;
import org.springframework.boot.test.mock.mockito.*;
import org.springframework.http.MediaType;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.web.servlet.MockMvc;

import be.pxl.vegisens.application.GrowableItem;
import be.pxl.vegisens.application.GrowableItemRestController;
import be.pxl.vegisens.application.IGrowableItemService;

import static org.mockito.BDDMockito.*;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.*;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.*;

/**
 * Created by aless on 2/11/2016.
 */

// Testing the controller layer

@RunWith(SpringRunner.class)
@WebMvcTest(GrowableItemRestController.class)
public class WebMvcTesting 
{

        @Autowired
        private MockMvc mvc;

        @MockBean
        private IGrowableItemService growableItemService;

        @Test
        public void getVehicleShouldReturnMakeAndModel() throws Exception 
        {
            GrowableItem expectedItem = new GrowableItem();
            expectedItem.setName("Cabbage");

            given(growableItemService.getGrowableItemById(1)).willReturn(expectedItem);

            mvc.perform(get("/growableItems/1").accept(MediaType.APPLICATION_JSON))
                    .andExpect(status().isOk())
                    .andExpect(content().string("Cabbage"));
        }
}