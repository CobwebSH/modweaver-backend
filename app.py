import imp
import json
import os
from flask import Flask
app = Flask(__name__)

@app.route('/')
def root():
    resp = app.make_response("{\"404\":\"Not Found\"}")
    resp.status_code = 200
    resp.mimetype = 'application/json'
    return resp
    
def four_zero_four():
    resp = app.make_response("{\"404\":\"Not Found\"}")
    resp.status_code = 404
    resp.mimetype = 'application/json'
    return resp

@app.route('/api/project/<project>')
def get_project(project):
    mods = os.listdir('mods/')
    list_of_mods = []
    for mod in mods:
        mod_name = mod.split('.json')[0]
        list_of_mods.append(mod_name)
        print(list_of_mods)
    for mod in list_of_mods:
        if mod == project:
            with open('mods/' + mod + '.json') as f:
                data = json.load(f)
                data = json.dumps(data)
            resp = app.make_response(data)
            resp.headers['Access-Control-Allow-Origin'] = '*'
            resp.mimetype = 'application/json'
            return resp
        elif mod.lower() == project.lower():
            data = "{\"404\":\"Not Found\"}"
            data = json.loads(data)
            data = json.dumps(data)
            resp = app.make_response(data)
            resp.status_code = 404
            resp.mimetype = 'application/json'
            return resp
    resp = app.make_response(data)
    resp.mimetype = "application/json"
    return resp
@app.route('/api/list_projects')
def list_projects():
    mods = os.listdir('mods/')
    list_of_mods = []
    for mod in mods:
        mod_name = mod.split('.json')[0]
        list_of_mods.append(mod_name)
    data = list_of_mods
    resp = app.make_response(json.dumps(data))
    resp.headers['Access-Control-Allow-Origin'] = '*'
    resp.mimetype = "application/json"
    return resp
