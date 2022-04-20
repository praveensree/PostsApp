import React from 'react';
import { Button, Card, Form, FormGroup } from 'reactstrap';
import ReactDOM from 'react-dom';


class EditComment extends React.Component {

    state = {

        commentDetail: this.props.commentDetail,
        commentId: this.props.commentId
    }

    onSubmit = (e) => {
        e.preventDefault();
        this.props.updateComment(this.state.commentId, this.state.commentDetail);

    }


    onChange = (e) => this.setState({ [e.target.name]: e.target.value });

    render() {
        // const{commentId,commentDetail}=this.props.comment
        return (
            <Card>
                <div className="card bg-light mb-3" style={{ width: '25rem', margin: 'auto' }}>
                    <div className="card-header">modify comment</div>
                    <div className="card-body">
                        <Form onSubmit={this.onSubmit}>
                            <FormGroup>
                                <textarea type="text" name="commentDetail"  rows="1" cols="45" value={this.state.commentDetail} onChange={this.onChange} />
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

export default EditComment;