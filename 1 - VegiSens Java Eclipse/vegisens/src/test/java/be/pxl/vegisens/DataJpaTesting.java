package be.pxl.vegisens;

import be.pxl.vegisens.application.GrowableItem;
import be.pxl.vegisens.application.GrowableItemRepository;
import be.pxl.vegisens.application.VegiSensApplication;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.boot.test.autoconfigure.orm.jpa.TestEntityManager;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

import static org.junit.Assert.*;

/**
 * Created by aless on 28/10/2016.
 */

// Testing the repository layer

@RunWith(SpringRunner.class)
@DataJpaTest
//@SpringBootTest(classes = VegiSensApplication.class)
public class DataJpaTesting {

    @Autowired
    private TestEntityManager entityManager;

    @Autowired
    private GrowableItemRepository growableItemRepository;

    @Before
    public void SetUp() {
        growableItemRepository.deleteAll();
    }

    @Test
    public void testGetGrowableItemByName_AfterPersistingNewGrowableItem() {
        GrowableItem insertedItem = new GrowableItem();
        insertedItem.setName("Tomato");
        entityManager.persist(insertedItem);

        GrowableItem searchedItem = growableItemRepository.getGrowableItemByName("Tomato");

        assertEquals("Tomato", searchedItem.getName());
    }
}