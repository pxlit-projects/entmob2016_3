package be.pxl.vegisens;

import be.pxl.vegisens.application.GrowableItem;
import be.pxl.vegisens.application.GrowableItemRestController;
import be.pxl.vegisens.application.IGrowableItemService;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.http.MediaType;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.web.servlet.MockMvc;

import static java.nio.file.Paths.get;
import static org.mockito.BDDMockito.given;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.*;

/**
 * Created by aless on 2/11/2016.
 */

// Testing the controller layer

@RunWith(SpringRunner.class)
@WebMvcTest(GrowableItemRestController.class)
public class WebMvcTesting {

        @Autowired
        private MockMvc mvc;

        @MockBean
        private IGrowableItemService growableItemService;

        @Test
        public void getVehicleShouldReturnMakeAndModel() {
            GrowableItem expectedItem = new GrowableItem();
            expectedItem.setName("Cabbage");

            given(growableItemService.getGrowableItemById(1))
                    .willReturn(expectedItem);

            mvc.perform(get("/growableItems").accept(MediaType.APPLICATION_JSON))
                    .andExpect(status().isOk())
                    .andExpect(content().string("Cabbage"));
        }
}