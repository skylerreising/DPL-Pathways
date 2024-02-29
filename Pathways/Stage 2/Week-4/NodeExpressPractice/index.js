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
    
    const schema = Joi.object({
        id: Joi.required(),
        name: Joi.string().min(3).required()
    })
    const { error, value } = schema.validate(newCourse)
    // const result = schema.validate({});
    // console.log(result)
    console.log(error, value);
    
    if(error){
        //400 Bad Request
        res.status(400).send(result.error);
        return;
    }
    
    courses.push(newCourse);
    res.send(newCourse);
})

app.get('/api/courses/:id', (req, res) => {
    const course = courses.find(c => c.id === parseInt(req.params.id))
    if(!course){
        res.status(404).send('The course with the given id was not found.');
    }else{
        res.send(course);
    }
})

const port = process.env.PORT || 2121;
app.listen(port, () => console.log(`Listening on port ${port}...`));