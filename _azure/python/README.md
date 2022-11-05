 py -m venv .venv

pip install -r requirements.txt

flask run

az webapp up --runtime PYTHON:3.9 --sku B1 --logs
