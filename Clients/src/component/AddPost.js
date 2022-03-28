import React from 'react';
import { Button, Modal, ModalHeader, ModalBody, Form, FormGroup } from 'reactstrap';
import {Card} from 'reactstrap';
	

class AddPost extends React.Component {
	state = {
		// modal: true,
		postName: '',
		postDescription: ''		
	}

	// toggle = () =>{
	// 	this.setState({modal : !this.state.modal})
	// }
	 onSubmit = (e) => {
	 	e.preventDefault();
    this.props.addpost(this.state.postName, this.state.postDescription);
    this.setState({ postName: '', postDescription: ''});
  }

  onChange = (e) => this.setState({ [e.target.name]: e.target.value });

	render(){
		return (
			<div class="card border-primary mb-3" style={{width: '40rem' , margin: 'auto'}}>
      			
        			 <Form onSubmit={this.onSubmit}>
        			  <FormGroup>
				       <input type="text" name="postName"  placeholder="Title ..." onChange={this.onChange} autofocus/>
				      </FormGroup>

				       <FormGroup>
       				    <textarea  name="postDescription" rows="5" cols="60" onChange={this.onChange} />
       				   </FormGroup>

       				   <FormGroup>
       				    <button type="submit" class="btn btn-primary" onClick={this.toggle}>Post</button>
       				   </FormGroup>

       				 </Form>
       		
    </div>
			
		)
	}
}

export default AddPost

 