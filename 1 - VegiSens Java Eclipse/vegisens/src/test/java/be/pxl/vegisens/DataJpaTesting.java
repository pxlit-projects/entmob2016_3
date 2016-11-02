package be.pxl.vegisens;

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

import be.pxl.vegisens.application.GrowableItem;
import be.pxl.vegisens.application.GrowableItemRepository;
import be.pxl.vegisens.application.SensorType;
import be.pxl.vegisens.application.SensorTypeRepository;

import static org.junit.Assert.*;

/**
 * Created by aless on 28/10/2016.
 */

@RunWith(SpringRunner.class) //Indicates that the class should use Spring's JUnit facilities
@DataJpaTest
public class DataJpaTesting
{

    @Autowired
    private TestEntityManager entityManager;

    @Autowired
    private GrowableItemRepository growableItemRepository;

    private SensorTypeRepository sensorTypeRepository;

    
    @Before
    public void SetUp() 
    {
        growableItemRepository.deleteAll();
    }

    @Test
    public void testGetGrowableItemById_AfterPersistingNewGrowableItem()
    {
        GrowableItem growableItemToPersist = new GrowableItem();
        growableItemToPersist.setGrowableItemId(1);
        entityManager.persist(growableItemToPersist);

        GrowableItem foundGrowableItemById = growableItemRepository.findOne(1);

        assertEquals(1, foundGrowableItemById.getGrowableItemId());	
    }
    
    @Test
    public void testGetSensrTypeById_AfterPersistingNewSensorType()
    {
        SensorType sensorTypeToPersist = new SensorType();
        sensorTypeToPersist.setSensortypeId(1);
        
        entityManager.persist(sensorTypeToPersist);

        SensorType foundSensorTypeById = sensorTypeRepository.findOne(1);

        assertEquals(1, foundSensorTypeById.getSensortypeId());		
    }
}