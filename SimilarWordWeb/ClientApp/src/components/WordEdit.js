﻿import React, { Fragment, useState } from 'react';
import { Form, FormControl, FormGroup, ControlLabel, Col, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';

const EditWord = ({ name, location }) => {
    // Declare a new state variable, which we'll call "count"
    const [word, setWord] = useState(location.state.word);

    const CallUpdateApi = (e) => {
        alert("in CallUpdateApi");
        console.log("CallUpdateApi");
        console.log(word);
        console.log(JSON.stringify(word));
        fetch('api/Words/', {
            method: 'POST',
            body: word,
            headers: {
                'Content-Type': 'application/json'
            }
            })
            .then(response => response.json())
                .then(json => console.log(json))
}

    const handleChange = (e) => {
        word[e.target.name] = e.target.value;
        setWord(word);
    }  
    //<p>You clicked {count} times</p>
    //<button onClick={() => setCount(count + 1)}>
    //    Click me
    //</button>
    console.log(name);
    console.log(location.state.word);
    return (
        <Fragment>
        <Form horizontal onSubmit={this.CallUpdateApi} >
            <h3 >Edit Word: {word.name}</h3>
            <FormField type='text' label="Word Name" val={word.name} ></FormField>

            <FormField type='text' label="Pronounciation" val={word.pronounciation} ></FormField>
            <FormField type='text' label="Frequency" val={word.frequency} ></FormField>
            <FormField type='textarea' label="Meaning Short" val={word.meaningShort} ></FormField>
            <FormField type='textarea' label="Meaning Long" val={word.meaningLong} ></FormField>
            <FormField type='text' label="Meaning Other" val={word.meaningOther} ></FormField>

            <FormGroup>
                <Col smOffset={2} sm={8}>
                    <button type="submit">Update</button>
                </Col>
            </FormGroup>
        </Form>
            <button onClick={CallUpdateApi}>Test</button>
        </Fragment>
    );
    }

const FormField = ({type, label, val }) => {
    return (
        <FormGroup controlId={"form" + label}>
            <Col componentClass={ControlLabel} sm={2}>
                {label}
            </Col>
            <Col sm={8}>
                {type === 'text' ?
                    <FormControl type={type} defaultValue={val} placeholder="Enter here" />
                    : <FormControl componentClass={type} defaultValue={val} placeholder="Enter here" />
                }
            </Col>
        </FormGroup>
    );
}


const SubmitWordEdit = (word) => {
    if (word.name.length <= 0) return;
    fetch('api/Words/' + word.name)
        .then(response => response.json())
        .then(data => {
            console.log('fetch word edit back');
        });
}


export default EditWord;
