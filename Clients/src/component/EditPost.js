import React, { Component } from 'react'
import { Card,Button,Form,FormGroup, Modal, ModalHeader, ModalBody } from 'reactstrap';

class EditPost extends Component {
    state = {
		postDescription:this.props.postDescription,
		postName:this.props.postName,
        postId:this.props.postId
	}
    onSubmit = (e) => {
        e.preventDefault();
   this.props.updatePost(this.state.postId, this.state.postName,this.state.postDescription);
    }

    
    
    onChange = (e) => this.setState({[e.target.name]: e.target.value});

    render() {
    return (
        <Card>
        <div class="card bg-light mb-3" style={{ width: '25rem', margin: 'auto' }}>
            <div class="card-header">modify Post</div>
            <div class="card-body">
                <Form onSubmit={this.onSubmit}>
                    <FormGroup>
                    <input type="text" name="postName" ref="postName" placeholder="Title ..." value={this.state.postName} onChange={this.onChange} autofocus/>
                    </FormGroup>
                    <FormGroup>
                        <textarea type="text" name="postDescription" ref="postDescription" rows="1" cols="45" value={this.state.postDescription} onChange={this.onChange} />
                    </FormGroup>
                    <FormGroup>
                        <p><Button type="submit" >Save</Button></p>
                    </FormGroup>
                </Form>
            </div>
        </div>
    </Card>
    );
  
}
 }

export default EditPost