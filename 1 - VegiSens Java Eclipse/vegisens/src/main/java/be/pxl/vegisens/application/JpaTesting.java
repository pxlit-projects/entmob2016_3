package be.pxl.vegisens.application;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.boot.test.autoconfigure.orm.jpa.TestEntityManager;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.transaction.annotation.Transactional;

import static org.junit.Assert.*;

/**
 * Created by aless on 28/10/2016.
 */

@RunWith(SpringRunner.class) //Indicates that the class should use Spring's JUnit facilities
@DataJpaTest
public class JpaTesting
{

    @Autowired
    private TestEntityManager entityManager;

    @Autowired
    private GrowableItemRepository growableItemRepository;

    @Before
    public void SetUp() 
    {
        growableItemRepository.deleteAll();
    }

    @Test
    public void testGetGrowableItemByName_AfterPersistingNewGrowableItem()
    {
        GrowableItem insertedItem = new GrowableItem();
        insertedItem.setName("Red Tomato");
        entityManager.persist(insertedItem);

        GrowableItem searchedItem = growableItemRepository.getGrowableItemByName("Red Tomato");

        assertEquals("Red Tomato", searchedItem.getName());	
    }
}