const express = require('express');
const Joi = require('joi');
const app = express();

app.use(express.json());// adding middleware that enables us to use json

const courses = [
    { id: 1, name: 'course1'},
    { id: 2, name: 'course2'},
    { id: 3, name: 'course3'},
]
app.get('/', (req,res) => {
    res.send('Hello World!!!');
});

app.get('/api/courses', (req,res) => {
   res.send(courses); 
});

app.post('/api/courses', (req,res) => {
    const newId = Math.max(...courses.map(course => course.id)) + 1;
    const newCourse = {
        id: newId,
        name: req.body.name
    };
    let { error} = validateCourse(req.body);

    if(error){
        //400 Bad Request
       return res.status(400).send(error.details[0].message);
    }

    console.log(error, value);
    
    courses.push(newCourse);
    res.send(newCourse);
})

app.put('/api/courses/:id', (req,res) => {
    let course = courses.find(c => c.id === parseInt(req.params.id))

    if(!course){
        return res.status(404).send('The course with the given id was not found.');
    }else{
        let { error} = validateCourse(req.body);
        
        if(error){
            //400 Bad Request
            return res.status(400).send(error.details[0].message);
        }
        
        //update course
        course.name = req.body.name;
        
        //return the updated course
        res.send(course);
    }
});

app.delete('/api/courses/:id', (req,res) => {
    let course = courses.find(c => c.id === parseInt(req.params.id))

    if(!course){
        return res.status(404).send('The course with the given id was not found.');
    }else{
        
        let index = courses.indexOf(course);
        courses.splice(index, 1);

        //return the updated course
        res.send(course);
    }
})

function validateCourse(course){
    const schema = Joi.object({
        // id: Joi.required(),
        name: Joi.string().min(3).required()
    });

    return { error, value } = schema.validate(course)
}

app.get('/api/courses/:id', (req, res) => {
    const course = courses.find(c => c.id === parseInt(req.params.id))
    if(!course){
        return res.status(404).send('The course with the given id was not found.');
    }else{
        res.send(course);
    }
})

const port = process.env.PORT || 2121;
app.listen(port, () => console.log(`Listening on port ${port}...`));